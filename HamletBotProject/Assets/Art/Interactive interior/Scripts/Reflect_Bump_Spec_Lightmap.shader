Shader "Reflect_Bump_Spec_Lightmap" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_ReflectColor ("Reflection Color", Color) = (1,0,0,1)
	_MainTex ("Base (RGB) RefStrGloss (A)", 2D) = "white" {}
	_Detail ("Detail (RGB)", 2D) = "gray" {}
	_Cube ("Reflection Cubemap", Cube) = "" { TexGen CubeReflect }
	_BumpMap ("Normalmap", 2D) = "bump" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 400
CGPROGRAM
#pragma surface surf BlinnPhong
#pragma target 3.0

sampler2D _MainTex;
sampler2D _Detail;
sampler2D _BumpMap;
samplerCUBE _Cube;

fixed4 _Color;
fixed4 _ReflectColor;
half _Shininess;

struct Input {
	//float2 uv_MainTex;
	float2 uv_BumpMap;
	float2 uv2_Detail;
	float3 worldRefl;
	INTERNAL_DATA
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_BumpMap);
	fixed4 c = tex * _Color;
	c.rgb *= tex2D(_Detail,IN.uv2_Detail).rgb*2;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
		
	o.Gloss = tex.a;
	o.Specular = _Shininess;
	
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	
	float3 worldRefl = WorldReflectionVector (IN, o.Normal);
	fixed4 reflcol = texCUBE (_Cube, worldRefl);
	reflcol *= tex.a;
	o.Emission = reflcol.rgb * _ReflectColor.rgb;
	o.Alpha = reflcol.a * _ReflectColor.a;
}
ENDCG
}

FallBack "Reflective/Bumped Diffuse"
}