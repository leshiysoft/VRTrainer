Shader "Unlit/HandSphere"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_Fading ("Fading", Float) = 3

		
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
			#include "UnityCG.cginc"

            struct v2f {
				half3 worldNormal : TEXCOORD0;
				float4 pos : SV_POSITION;
				half3 campos : TEXCOORD1;
			};

			v2f vert(float4 vertex : POSITION, float3 normal : NORMAL)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(vertex);
				o.worldNormal = normalize(mul(unity_ObjectToWorld, normal));
				o.campos = normalize(WorldSpaceViewDir(vertex));
				return o;
			}

			fixed4 _Color;
			fixed _Fading;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 c;
				c.rgb = _Color.rgb;
				c.a = pow(clamp(dot(i.campos, i.worldNormal),0,1),abs(_Fading))*_Color.a;
				return c;
			}

			ENDCG
        }
    }
}
