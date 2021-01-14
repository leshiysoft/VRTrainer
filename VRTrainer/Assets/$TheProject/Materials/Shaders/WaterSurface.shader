Shader "Custom/WaterSurface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Bumpmap", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

		//ZWrite Off
		//Blend SrcAlpha OneMinusSrcAlpha
		//Cull front

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;
		sampler2D _BumpMap;

        struct Input
        {
            //float2 uv_MainTex;
			float2 uv_BumpMap;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
       // UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = /*tex2D (_MainTex, IN.uv_MainTex) */ _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
			
			float2 uvNormal = IN.uv_BumpMap;
			uvNormal.x += _Time.x;
			uvNormal.y += _Time.x;

			float3 n1 = UnpackNormal(tex2D(_BumpMap, uvNormal));

			uvNormal = IN.uv_BumpMap;
			uvNormal.x -= 0.97*_Time.x;
			uvNormal.y += 0.97*_Time.x;

			float3 n2 = UnpackNormal(tex2D(_BumpMap, uvNormal));

			uvNormal = IN.uv_BumpMap;
			uvNormal.x += 1.13*_Time.x;
			uvNormal.y -= 1.13*_Time.x;

			float3 n3 = UnpackNormal(tex2D(_BumpMap, uvNormal));

			uvNormal = IN.uv_BumpMap;
			uvNormal.x -= 1.07*_Time.x;
			uvNormal.y -= 1.07*_Time.x;

			float3 n4 = UnpackNormal(tex2D(_BumpMap, uvNormal));

			float3 normal = BlendNormals(BlendNormals(n1, n2), BlendNormals(n3, n4));

			normal = BlendNormals(BlendNormals(n1, n2), BlendNormals(n3, n4));

			normal.xy = 0.2 * normal.xy;

			normal.z = sqrt(1.0 - saturate(dot(normal.xy, normal.xy)));

			o.Normal = normal;
        }
        ENDCG
    }
    //FallBack "Transparent"
}
