// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// 创建者:   Harling
// 创建时间: 2020-09-28 23:07:33
// 备注:     由PIToolKit工具生成

Shader "Hidden/PIToolKit/Foundation/Map" 
{
	Properties 
	{
		_MainTex("MainTex",2D)="white"{}
	}
	SubShader 
	{
		Tags {"RenderType" = "Opaque" "Queue"="Transparent"}
		
		pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Back
			CGPROGRAM
			
			#pragma target 4.0
			#pragma multi_compile_instancing
			
			#include "UnityCG.cginc"
			
			#pragma vertex vert
			#pragma fragment frag
			
			sampler2D _MainTex;
			float4 _MainTex_ST;

			struct v2f
			{
				float2 UV:TEXCOORD0;
				UNITY_VERTEX_OUTPUT_STEREO
				UNITY_VERTEX_INPUT_INSTANCE_ID 
			};
			
			void vert(appdata_base adb,uint id:SV_INSTANCEID,out v2f o,out float4 pos:POSITION)
			{
				UNITY_SETUP_INSTANCE_ID(adb);
				UNITY_TRANSFER_INSTANCE_ID(adb, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				
				pos=UnityObjectToClipPos(adb.vertex);
				o.UV=adb.texcoord;
				o.UV=o.UV * _MainTex_ST.xy + _MainTex_ST.zw;
			}

			void frag(v2f data,out fixed4 col:SV_TARGET)
			{
				UNITY_SETUP_INSTANCE_ID(data);
				
				col=tex2D(_MainTex,data.UV);
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
