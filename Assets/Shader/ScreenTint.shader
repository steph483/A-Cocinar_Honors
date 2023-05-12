Shader "Unlit/ScreenTint"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    CGINCLUDE
        #include "UnityCG.cginc"

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            //UNITY_FOG_COORDS(1)
            float4 vertex : SV_POSITION;
        };

        sampler2D _MainTex;
        //float4 _MainTex_ST;

        v2f vert (appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = v.uv;
            //o.uv = TRANSFORM_TEX(v.uv, _MainTex);
            //UNITY_TRANSFER_FOG(o,o.vertex);
            return o;
        }
    ENDCG

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        /*
        Pass //pass 0
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            //#pragma multi_compile_fog

            fixed4 _ScreenTint;

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                //return col * _ScreenTint;
                return col;
            }
            ENDCG
        }
        */
        

        Pass //pass 1
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            fixed4 _Radius;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float newUV = i.uv * 2 - 1;

                // Find the center of the circle
                float2 center = float2(0.5, 0.5);

                // Calculate the distance from the center to the current pixel
                float dist = distance(center, i.uv);

                //float circle = length(newUV);
                float mask = step(dist, _Radius);

                return fixed4(mask.xxx, 1);
              
            }
            ENDCG
        }
    }
}
