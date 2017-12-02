using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGOpenGL2
{
    class Parames
    {
        /* Золото */
        public static float[] mat1_dif = { 0.8f, 0.8f, 0.0f };
        public static float[] mat1_amb = { 0.2f, 0.2f, 0.2f };
        public static float[] mat1_spec = { 0.6f, 0.6f, 0.6f };
        public static float mat1_shiness = 0.5f * 128;
        /* Серебро */
        public static float[] mat2_dif = { 0.95f, 1.0f, 0.95f };
        public static float[] mat2_amb = { 0.2f, 0.2f, 0.2f };
        public static float[] mat2_spec = { 0.6f, 0.6f, 0.6f };
        public static float mat2_shiness = 0.7f * 128;
        /* Бронза */
        public static float[] mat3_dif = { 0.9f, 0.5f, 0.0f };
        public static float[] mat3_amb = { 0.2f, 0.2f, 0.2f };
        public static float[] mat3_spec = { 0.6f, 0.6f, 0.6f };
        public static float mat3_shiness = 0.1f * 128;

        /*для нулевого источника света*/
        public static float[] light0_ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        public static float[] light0_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        public static float[] light0_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        public static float[] light0_position = { 1.0f, 1.0f, 1.0f, 0.0f };

        /*для первого источника света*/
        public static float[] light1_ambient = { 1.0f, 1.0f, 1.0f, 1.0f };
        public static float[] light1_diffuse = { 0.4f, 0.7f, 0.2f, 0.0f };
        public static float[] light1_specular = { 0.0f, 1.0f, 0.0f, 1.0f };
        public static float[] light1_position = { 0.0f, 0.0f, 1.0f, 0.0f };

		/*для второго источника света*/
		public static float[] light2_ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
		public static float[] light2_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
		public static float[] light2_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
		public static float[] light2_position = { 0.0f, 0.0f, 1000.0f, 0.0f };

	}
}
