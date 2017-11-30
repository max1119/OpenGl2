using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace CGOpenGL2
{
    class Test
    {

        /* параметры материала тора */
        static float[] mat1_dif = { 0.8f, 0.8f, 0.0f };
        static float[] mat1_amb = { 0.2f, 0.2f, 0.2f };
        static float[] mat1_spec = { 0.6f, 0.6f, 0.6f };
        static float mat1_shiness = 0.5f * 128;
        /* параметры материала конуса */
        static float[] mat2_dif = { 0.0f, 0.0f, 0.8f };
        static float[] mat2_amb = { 0.2f, 0.2f, 0.2f };
        static float[] mat2_spec = { 0.6f, 0.6f, 0.6f };
        static float mat2_shiness = 0.7f * 128;
        /* параметры материала шара */
        static float[] mat3_dif = { 0.9f, 0.2f, 0.0f };
        static float[] mat3_amb = { 0.2f, 0.2f, 0.2f };
        static float[] mat3_spec = { 0.6f, 0.6f, 0.6f };
        static float mat3_shiness = 0.1f * 128;

        static float[] light_ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        static float[] light_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        static float[] light_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        static float[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };

        private static void DrawTorus()
        {
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat1_amb);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat1_dif);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat1_spec);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, mat1_shiness);
            Gl.glPushMatrix();
            Gl.glTranslatef(-0.75f, 0.5f, -10.0f);
            Gl.glRotated(20.0, 1.0, 0.0, 0.0);
            Gl.glRotated(90.0, 1.0, 0.0, 0.0);
            Glut.glutSolidTorus(0.275, 0.85, 15, 15);
            Gl.glPopMatrix();
        }

        private static void DrawCone()
        {
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat2_amb);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat2_dif);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat2_spec);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, mat2_shiness);
            Gl.glPushMatrix();
            Gl.glTranslatef(-0.75f, -0.5f, -10.0f);
            Gl.glRotated(20.0, 1.0, 0.0, 0.0);
            Gl.glRotated(270.0, 1.0, 0.0, 0.0);
            Glut.glutSolidCone(1.0, 2.0, 15, 15);
            Gl.glPopMatrix();
        }

        private static void DrawSphere()
        {
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat3_amb);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat3_dif);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat3_spec);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, mat3_shiness);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.75f, 0.0f, -11.0f);
            Gl.glRotated(20.0, 1.0, 0.0, 0.0);
            Glut.glutSolidSphere(1.0, 15, 15);
            Gl.glPopMatrix();
        }


        public static void Display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);            
            Gl.glPushMatrix();            
            DrawTorus();
            DrawCone();
            DrawSphere();
            Gl.glPopMatrix();
            Gl.glFlush();
            Glut.glutSwapBuffers();
        }

        public static void RenderWireSphere()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -6);
            Gl.glRotated(45, 1, 1, 0);
            Glut.glutWireSphere(2, 32, 32);
            Gl.glPopMatrix();
            Gl.glFlush();
            Glut.glutSwapBuffers();
        }

    }
}
