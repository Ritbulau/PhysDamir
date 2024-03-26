using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace PhysDam
{
    public class ExtraFunc {public virtual void Update(int Index) { } }

    public class TimeStopButton : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.TimeScale = Global.TimeScale == 1 ? 0 : 1;
                Global.Buttons[Index].MainColor = Global.TimeScale == 1 ? Color.Green : Color.Red;
            }
        }
    }

    public class SpawnButton : ExtraFunc
    {
        public override void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                PhysicalObject Object = new PhysicalObject();
                int i = Global.Objects.Count;
                Object.Type = "circle";
                Object.Mass = 10;
                Object.SystemName = $"Circle {i + 1}";
                Object.Index = i;
                Object.Radius = Global.ConstRad;
                Object.SetOrigin();
                Object.Pos = new Vector2f(100, 200);
                Object.ObjectColor = Color.White;
                Object.RectSize = new Vector2f(50, 50);
                Global.Objects.Add(Object);
            }
        }
    }
    public class SpawnCube : ExtraFunc
    {
        public override void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                PhysicalObject Object = new PhysicalObject();
                int i = Global.Objects.Count;
                Object.Type = "rect";
                Object.Mass = 10;
                Object.SystemName = $"Circle {i + 1}";
                Object.Index = i;
                Object.Radius = Global.ConstRad;
                Object.SetOrigin();
                Object.Pos = new Vector2f(100, 300);
                Object.ObjectColor = Color.White;
                Object.RectSize = new Vector2f(50, 50);
                Global.Objects.Add(Object);
            }
        }
    }

    public class AddRad : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.ConstRad += 2;
            }
        }
    }
    public class SubsRad : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.ConstRad -= 2;
            }
        }
    }

    public class AddPosXp : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Pos.X += 5;
            }
        }
    }
    public class AddPosXn : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Pos.X -= 5;
            }
        }
    }
    public class AddPosYp : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Pos.Y -= 5;
            }
        }
    }
    public class AddPosYn : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Pos.Y += 5;
            }
        }
    }

    public class PadXp : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                if(Global.Objects[Global.SelectedID].Type == "rect")
                {
                    Global.Objects[Global.SelectedID].RectSize.X += 5;
                }
                else
                {
                    Global.Objects[Global.SelectedID].Speed.X += 5;
                }
            }
        }
    }
    public class PadXn : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                if (Global.Objects[Global.SelectedID].Type == "rect")
                {
                    Global.Objects[Global.SelectedID].RectSize.X -= 5;
                }
                else
                {
                    Global.Objects[Global.SelectedID].Speed.X -= 5;
                }
            }
        }
    }
    public class PadYp : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                if (Global.Objects[Global.SelectedID].Type == "rect")
                {
                    Global.Objects[Global.SelectedID].RectSize.Y += 5;
                }
                else
                {
                    Global.Objects[Global.SelectedID].Speed.Y -= 5;
                }
            }
        }
    }
    public class PadYn : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                if (Global.Objects[Global.SelectedID].Type == "rect")
                {
                    Global.Objects[Global.SelectedID].RectSize.Y -= 5;
                }
                else
                {
                    Global.Objects[Global.SelectedID].Speed.Y += 5;
                }
            }
        }
    }

    public class RotP : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Rotation += 5;
            }
        }
    }
    public class RotN : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Rotation -= 5;
            }
        }
    }

    public class Delete : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                if (Global.ControlledObject == Global.Objects[Global.SelectedID].SystemName) Global.ControlledObject = "";
                Global.Objects.RemoveAt(Global.SelectedID);
                CustomFunctions.ResetObjectsIndexes();
                Global.SelectedID = -1;
            }
        }
    }
    public class TakeControl : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.ControlledObject = Global.Objects[Global.SelectedID].SystemName == Global.ControlledObject ? "" : Global.Objects[Global.SelectedID].SystemName;
            }
        }
    }
    public class UseGravity : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].UseGravity = !Global.Objects[Global.SelectedID].UseGravity;
            }
        }
    }
    public class AddMass : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Mass += 1f;
            }
        }
    }
    public class RedMass : ExtraFunc
    {
        override public void Update(int Index)
        {
            if (Global.Buttons[Index].CheckPressed())
            {
                Global.Objects[Global.SelectedID].Mass -= 1f;
            }
        }
    }
    public class ChangeColorOverTime : ExtraFunc
    {
        override public void Update(int Index)
        {
            Global.Objects[Index].ObjectColor = new Color((byte)(Math.Sin(Global.GlobalTime * 1 + 10 * Index) * 255), (byte)(Math.Sin(Global.GlobalTime * 1 + 20 * Index) * 255), (byte)(Math.Sin(Global.GlobalTime * 1 + 30 * Index) * 255));
        }
    }




    static class CustomFunctions
    {
        public static int FindObjectByName(string Name)
        {
            for (int i = 0; i < Global.Objects.Count; i++)
            {
                if (Global.Objects[i].SystemName == Name)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int FBBN(string Name)
        {
            for (int i = 0; i < Global.Buttons.Count; i++)
            {
                if (Global.Buttons[i].Name == Name)
                {
                    return i;
                }
            }
            return -1;
        }
        public static float VectorDistance(Vector2f V1, Vector2f V2)
        {
            return (float)(Math.Sqrt(Math.Pow((V2.X - V1.X), 2) + Math.Pow((V2.Y - V1.Y), 2)));
        }
        public static float VectorMagnitude(Vector2f V)
        {
            return (float)(VectorDistance(new Vector2f(0, 0), V));
        }
        public static Vector2f VectorNormalized(Vector2f Vector)
        {
            float Dist = VectorDistance(new Vector2f(0, 0), Vector);
            return new Vector2f(Vector.X / Dist, Vector.Y / Dist);
        }
        public static Vector2f Direction(Vector2f Point1, Vector2f Point2)
        {
            return new Vector2f(Point2.X - Point1.X, Point2.Y - Point1.Y);
        }
        public static Vector2f OppositeVector(Vector2f Point)
        {
            return new Vector2f(-Point.X, -Point.Y);
        }
        public static Vector2f RotateVec90ToRight(Vector2f Vector)
        {
            return new Vector2f(-Vector.Y, Vector.X);
        }
        public static Vector2f RotateVec90ToLeft(Vector2f Vector)
        {
            return new Vector2f(Vector.Y, -Vector.X);
        }
        public static float VectorsDot(Vector2f Vector1, Vector2f Vector2)
        {
            return Vector1.X * Vector2.X + Vector1.Y * Vector2.Y;
        }
        public static float Clamp(float Value, float Min, float Max)
        {
            if (Value > Max) Value = Max;
            else if (Value < Min) Value = Min;
            return Value;
        }
        public static Vector2f VectorSubs(Vector2f Start, Vector2f Dest)
        {
            return (new Vector2f(Dest.X - Start.X, Dest.Y - Start.Y));
        }
        public static Vector2f VectorSumm(Vector2f Start, Vector2f Dest)
        {
            return (new Vector2f(Start.X + Dest.X, Start.Y + Dest.Y));
        }
        public static Vector2f ReflectVector(Vector2f vector, Vector2f point1, Vector2f point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

            float vectorAngle = (float)Math.Atan2(vector.Y, vector.X);

            float incidentAngle = vectorAngle - angle;

            float reflectionAngle = angle - incidentAngle;

            float vectorLength = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

            vector.X = vectorLength * (float)Math.Cos(reflectionAngle);
            vector.Y = vectorLength * (float)Math.Sin(reflectionAngle);
            return vector;
        }
        public static Vector2f Rotate(Vector2f V, float degrees)
        {
            float radians = degrees * (float)Math.PI / 180.0f;
            float cosTheta = (float)Math.Cos(radians);
            float sinTheta = (float)Math.Sin(radians);

            float newX = V.X * cosTheta - V.Y * sinTheta;
            float newY = V.X * sinTheta + V.Y * cosTheta;

            V.X = newX;
            V.Y = newY;

            return V;
        }
        public static bool CheckCross(Vector2f p1, Vector2f p2, Vector2f p3, Vector2f p4)
        {
            float x1 = p1.X;
            float y1 = p1.Y;
            float x2 = p2.X;
            float y2 = p2.Y;
            float x3 = p3.X;
            float y3 = p3.Y;
            float x4 = p4.X;
            float y4 = p4.Y;

            float denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            return denominator != 0;
        }
        public static Vector2f CalculateCross(Vector2f p1, Vector2f p2, Vector2f p3, Vector2f p4)
        {
            float x1 = p1.X;
            float y1 = p1.Y;
            float x2 = p2.X;
            float y2 = p2.Y;
            float x3 = p3.X;
            float y3 = p3.Y;
            float x4 = p4.X;
            float y4 = p4.Y;

            float denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            float intersectX = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominator;
            float intersectY = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominator;

            return new Vector2f(intersectX, intersectY);
        }
        public static bool IsInside(Vector2f p, List<Vector2f> vertices)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Orientation(vertices[i], vertices[(i + 1) % 4], p) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static float Orientation(Vector2f p, Vector2f q, Vector2f r)
        {
            return (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
        }


        public static void AddRandomPosObject()
        {
            int PosX = Global.RND.Next(40, 760);
            int PosY = Global.RND.Next(40, 560);

            PhysicalObject po = new PhysicalObject();
            int i = Global.Objects.Count;
            po.Type = "circle";
            po.SystemName = $"Circle {i + 1}";
            po.Index = i;
            po.Radius = Global.ConstRad;
            po.Mass = 10;
            po.ObjectColor = Color.Yellow;
            po.SetOrigin();
            po.Pos = new Vector2f(PosX, PosY);
            //po.Func = new ChangeColorOverTime();
            Global.Objects.Add(po);
        }
        public static void AddObject(Vector2f Position, float Mass, Color ObjectColor, string Name, float Radius, string Type, Vector2f RectSize)
        {
            PhysicalObject Object = new PhysicalObject();
            int i = Global.Objects.Count;
            Object.Type = Type;
            Object.Mass = Mass;
            Object.SystemName = $"Circle {i + 1}";
            Object.Name = Name;
            Object.Index = i;
            Object.Radius = Radius;
            Object.SetOrigin();
            Object.Pos = Position;
            Object.ObjectColor = ObjectColor;
            Object.RectSize = RectSize;
            Global.Objects.Add(Object);
        }

        public static void AddButton(Vector2f Position, Vector2f Size, Color ButtonColor, Color HighlightColor, string Name, ExtraFunc Function)
        {
            Button btn = new Button();
            int i = Global.Buttons.Count;
            btn.Pos = Position;
            btn.Size = Size;
            btn.MainColor = ButtonColor;
            btn.HighlightColor = HighlightColor;
            btn.Name = Name;
            btn.Index = i;
            btn.Func = Function;
            Global.Buttons.Add(btn);
        }

        public static void ResetObjectsIndexes()
        {
            for(int i = 0; i < Global.Objects.Count; i++)
            {
                Global.Objects[i].Index = i;
            }
        }
    }


    static class Global
    {
        public static float DeltaTime = 0;

        public static List<PhysicalObject> Objects = new List<PhysicalObject>();
        public static List<Button> Buttons = new List<Button>();

        public static Random RND = new Random();
        public static Event events = new Event();

        public static float TimeScale = 1f;
        public static float ConstRad = 25;
        public static float XWallEff = 1f;
        public static float YWallEff = 1f;

        public static List<RectangleShape> Rects = new List<RectangleShape>();

        public static double GlobalTime;

        public static int SelectedID = -1;
        public static string ControlledObject = "";
    }


    static class Constants
    {
        public static readonly Vector2f VectorZero = new Vector2f(0, 0);
        public static readonly Vector2i VectorZeroI = new Vector2i(0, 0);
        public static readonly Vector2u WindowSize = new Vector2u(1100, 600);
    }

    static class Input
    {
        public static Vector2i MousePos;

        static bool ML;

        public static bool MouseLeft;

        public static void CheckButtons()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (ML)
                {
                    MouseLeft = false;
                }
                if (!ML)
                {
                    MouseLeft = true;
                    ML = true;
                }
            }
            if (!Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                ML = false;
                MouseLeft = false;
            }
        }
    }

    /// <summary>
    /// 
    ///     PROGRAMM LOOP
    /// 
    /// </summary>


    class PhysDam
    {
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }



        static void Main()
        {

            ContextSettings Preferences = new ContextSettings(0, 0, 8);

            RenderWindow app = new RenderWindow(new VideoMode(Constants.WindowSize.X, Constants.WindowSize.Y), "PhysDam", Styles.Default, Preferences);
            app.Closed += new EventHandler(OnClose);
            Color windowColor = Color.Black;

            Stopwatch DeltaWatch = new Stopwatch();
            float DeltaTime = 0f;

            //
            //    UI
            //

            //Main Panel

            RectangleShape MPR = new RectangleShape();
            MPR.FillColor = new Color(128, 128, 128);
            MPR.Size = new Vector2f(800, 100);
            Global.Rects.Add(MPR);

            //Shape Inspector

            RectangleShape SI = new RectangleShape();
            SI.Position = new Vector2f(800, 0);
            SI.FillColor = new Color(100, 100, 100);
            SI.Size = new Vector2f(300, 600);
            Global.Rects.Add(SI);


            CustomFunctions.AddButton(new Vector2f(30, 30), new Vector2f(50, 50), Color.White, Color.Cyan, "", new SpawnButton());
            CustomFunctions.AddButton(new Vector2f(100, 30), new Vector2f(50, 50), Color.White, Color.Cyan, "", new SpawnCube());
            CustomFunctions.AddButton(new Vector2f(170, 30), new Vector2f(50, 50), Color.Green, Color.Yellow, "", new TimeStopButton());
            CustomFunctions.AddButton(new Vector2f(240, 30), new Vector2f(50, 50), Color.White, Color.Cyan, "", new AddRad());
            CustomFunctions.AddButton(new Vector2f(310, 30), new Vector2f(50, 50), Color.White, Color.Cyan, "", new SubsRad());
            CustomFunctions.AddButton(new Vector2f(1030, 530), new Vector2f(50, 50), Color.Red, new Color(128, 0, 0), "Delete", new Delete());

            CustomFunctions.AddButton(new Vector2f(960, 530), new Vector2f(50, 50), Color.Green, new Color(0, 128, 0), "Control", new TakeControl());
            CustomFunctions.AddButton(new Vector2f(890, 530), new Vector2f(50, 50), Color.Blue, new Color(0, 0, 128), "UseGravity", new UseGravity());

            CustomFunctions.AddButton(new Vector2f(850, 400), new Vector2f(40, 40), Color.White, Color.Cyan, "APYN", new AddPosYn());
            CustomFunctions.AddButton(new Vector2f(850, 320), new Vector2f(40, 40), Color.White, Color.Cyan, "APYP", new AddPosYp());
            CustomFunctions.AddButton(new Vector2f(810, 360), new Vector2f(40, 40), Color.White, Color.Cyan, "APXN", new AddPosXn());
            CustomFunctions.AddButton(new Vector2f(890, 360), new Vector2f(40, 40), Color.White, Color.Cyan, "APXP", new AddPosXp());

            CustomFunctions.AddButton(new Vector2f(1000, 400), new Vector2f(40, 40), Color.White, Color.Cyan, "PYN", new PadYn());
            CustomFunctions.AddButton(new Vector2f(1000, 320), new Vector2f(40, 40), Color.White, Color.Cyan, "PYP", new PadYp());
            CustomFunctions.AddButton(new Vector2f(960, 360), new Vector2f(40, 40), Color.White, Color.Cyan, "PXN", new PadXn());
            CustomFunctions.AddButton(new Vector2f(1040, 360), new Vector2f(40, 40), Color.White, Color.Cyan, "PXP", new PadXp());

            CustomFunctions.AddButton(new Vector2f(820, 460), new Vector2f(40, 40), Color.White, Color.Cyan, "RN", new RotN());
            CustomFunctions.AddButton(new Vector2f(880, 460), new Vector2f(40, 40), Color.White, Color.Cyan, "RP", new RotP());

            CustomFunctions.AddButton(new Vector2f(880, 260), new Vector2f(40, 40), Color.White, Color.Cyan, "AM", new AddMass());
            CustomFunctions.AddButton(new Vector2f(820, 260), new Vector2f(40, 40), Color.White, Color.Cyan, "RM", new RedMass());


            // Start the game loop
            while (app.IsOpen)
            {

                // Process events
                DeltaWatch.Start();
                app.DispatchEvents();
                Input.CheckButtons();
                app.Size = Constants.WindowSize;
                Global.GlobalTime += DeltaTime;

                // Clear screen
                app.Clear(windowColor);

                //BODY


                if (Global.ControlledObject != "")
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    {
                        Global.Objects[CustomFunctions.FindObjectByName(Global.ControlledObject)].AddSpeed(new Vector2f(0, -500) * Global.DeltaTime);
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    {
                        Global.Objects[CustomFunctions.FindObjectByName(Global.ControlledObject)].AddSpeed(new Vector2f(-500, 0) * Global.DeltaTime);
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    {
                        Global.Objects[CustomFunctions.FindObjectByName(Global.ControlledObject)].AddSpeed(new Vector2f(0, 500) * Global.DeltaTime);
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    {
                        Global.Objects[CustomFunctions.FindObjectByName(Global.ControlledObject)].AddSpeed(new Vector2f(500, 0) * Global.DeltaTime);
                    }
                }


                for (int i = 0; i < Global.Objects.Count; i++)
                {
                    //Main Properties
                    Global.Objects[i].SetProperties();
                    Global.Objects[i].SetOrigin();
                    Global.Objects[i].Radius = Global.ConstRad;

                    //Physics
                    if (Global.Objects[i].Type != "rect")
                    {
                        Global.Objects[i].SolveForcesTime();
                        Global.Objects[i].SolveAcceleration();
                        Global.Objects[i].SolveSpeed();
                        Global.Objects[i].SolveMovement();
                        Global.Objects[i].SolvePosition();
                        if (Global.TimeScale != 0) Global.Objects[i].SolveCollision(app);

                        Global.Objects[i].SolveWalls();
                        Global.Objects[i].AddGravity();
                    }


                    //Other
                    if (Global.Objects[i].Func != null) Global.Objects[i].Func.Update(i);
                    Global.Objects[i].HighLight();
                    if (Global.Objects[i].CheckMouseOver() && Input.MouseLeft) Global.SelectedID = Global.SelectedID == i ? -1 : i;

                    //Render
                    Global.Objects[i].DrawCircle(app);
                }

                for (int i = 0; i < Global.Rects.Count; i++)
                {
                    //Render
                    app.Draw(Global.Rects[i]);
                }

                for (int i = 0; i < Global.Buttons.Count; i++)
                {
                    if (Global.Buttons[i].Active)
                    {
                        //Main
                        Global.Buttons[i].Init();
                        Global.Buttons[i].Func.Update(i);

                        //Render
                        Global.Buttons[i].Draw(app);
                    }
                }

                Global.Buttons[CustomFunctions.FBBN("Delete")].Active = Global.SelectedID != -1;

                Global.Buttons[CustomFunctions.FBBN("APYN")].Active = Global.SelectedID != -1;
                Global.Buttons[CustomFunctions.FBBN("APYP")].Active = Global.SelectedID != -1;
                Global.Buttons[CustomFunctions.FBBN("APXN")].Active = Global.SelectedID != -1;
                Global.Buttons[CustomFunctions.FBBN("APXP")].Active = Global.SelectedID != -1;

                Global.Buttons[CustomFunctions.FBBN("PYN")].Active = Global.SelectedID != -1;
                Global.Buttons[CustomFunctions.FBBN("PYP")].Active = Global.SelectedID != -1;
                Global.Buttons[CustomFunctions.FBBN("PXN")].Active = Global.SelectedID != -1;
                Global.Buttons[CustomFunctions.FBBN("PXP")].Active = Global.SelectedID != -1;

                if (Global.SelectedID != -1 && Global.Objects[Global.SelectedID].Type != "rect")
                {
                    Global.Buttons[CustomFunctions.FBBN("Control")].Active = true;
                    Global.Buttons[CustomFunctions.FBBN("UseGravity")].Active = true;

                    Global.Buttons[CustomFunctions.FBBN("AM")].Active = true;
                    Global.Buttons[CustomFunctions.FBBN("RM")].Active = true;
                }
                else
                {
                    Global.Buttons[CustomFunctions.FBBN("Control")].Active = false;
                    Global.Buttons[CustomFunctions.FBBN("UseGravity")].Active = false;

                    Global.Buttons[CustomFunctions.FBBN("AM")].Active = false;
                    Global.Buttons[CustomFunctions.FBBN("RM")].Active = false;
                }

                Global.Buttons[CustomFunctions.FBBN("RN")].Active = Global.SelectedID != -1 && Global.Objects[Global.SelectedID].Type == "rect";
                Global.Buttons[CustomFunctions.FBBN("RP")].Active = Global.SelectedID != -1 && Global.Objects[Global.SelectedID].Type == "rect";

                //END BODY

                // Update the window
                app.Display();
                DeltaWatch.Stop();
                DeltaTime = (float)DeltaWatch.Elapsed.TotalSeconds;
                DeltaTime = CustomFunctions.Clamp(DeltaTime, 0, 0.02f);
                Global.DeltaTime = DeltaTime * Global.TimeScale;
                DeltaWatch.Reset();
                Input.MousePos = Mouse.GetPosition(app);
            } //End game loop
        } //End Main()
    }



    /// <summary>
    /// 
    ///     PHYSICAL OBJECT CODE
    /// 
    /// </summary>



    class PhysicalObject
    {
        public Shape PhysObject = new RectangleShape();
        public Color ObjectColor = Color.White;
        public float Radius = 100f;
        public float Mass = 1f;
        public List<Force> Forces = new List<Force>();
        public Vector2f Acceleration = Constants.VectorZero;
        public Vector2f Speed = Constants.VectorZero;
        public Vector2f Pos = Constants.VectorZero;
        public float Rotation = 0;
        public string Name = "";
        public string SystemName = "";
        public string Type = "";
        public int Index = -1;
        public float Gravity = 9.81f;
        public bool UseGravity = true;
        public ExtraFunc Func = null;

        public Vector2f RectSize;

        public void DrawCircle(RenderWindow Window)
        {
            Window.Draw(PhysObject);
        }
        public void SetOrigin()
        {
            if(Type == "rect") PhysObject.Origin = RectSize/2;
            else PhysObject.Origin = new Vector2f(Radius, Radius);
        }
        public void AddPosition(Vector2f Add)
        {
            Pos = new Vector2f(Pos.X + Add.X, Pos.Y + Add.Y);
        }
        public void SetProperties()
        {
            switch (Type)
            {
                case "circle":
                    PhysObject = new CircleShape(Radius);
                    break;

                case "rect":
                    PhysObject = new RectangleShape(RectSize);
                    break;

                default:
                    PhysObject = new CircleShape(Radius);
                    break;
            }
            PhysObject.FillColor = ObjectColor;
            PhysObject.Position = Pos;
            PhysObject.Rotation = Rotation;
        }

        public void AddForce(Vector2f V, float T, string Name)
        {
            if (Name == null)
            {
                Name = $"Force {Forces.Count}";
            }
            Force NewForce = new Force();
            NewForce.Vector = V;
            NewForce.Time = T;
            Forces.Add(NewForce);
        }
        public int FindForceIndex(Vector2f V, float T)
        {
            int i = -1;
            for (int j = 0; i < Forces.Count; j++)
            {
                if (Forces[j].Vector == V && Forces[j].Time == T)
                {
                    i = j;
                    break;
                }
            }
            return i;
        }
        public int FindForceIndexByVector(Vector2f V)
        {
            int i = -1;
            for (int j = 0; j < Forces.Count; j++)
            {
                if (Forces[j].Vector == V)
                {
                    i = j;
                    break;
                }
            }
            return i;
        }
        public int FindForceIndexByTime(float T)
        {
            int i = -1;
            for (int j = 0; i < Forces.Count; j++)
            {
                if (Forces[j].Time == T)
                {
                    i = j;
                    break;
                }
            }
            return i;
        }
        public int FindForceIndexByName(string N)
        {
            int i = -1;
            for (int j = 0; j < Forces.Count; j++)
            {
                if (Forces[j].Name == N)
                {
                    i = j;
                    break;
                }
            }
            return i;
        }
        public void RemoveForce(int I)
        {
            Forces.RemoveAt(I);
        }
        public void AddSpeed(Vector2f Vel)
        {
            Speed += Vel;
        }
        public void SolveAcceleration()
        {
            Acceleration = Constants.VectorZero;
            for (int i = 0; i < Forces.Count; i++)
            {
                Acceleration += Forces[i].Vector / Mass * Global.DeltaTime;
            }
        }
        public void SolveSpeed()
        {
            Speed = Speed + Acceleration * Global.DeltaTime;
        }
        public void SolveMovement()
        {
            Pos = Pos + Speed * Global.DeltaTime;
        }
        public void SolvePosition()
        {
            PhysObject.Position = Pos;
        }
        public void SolveAttraction()
        {
            if (Name != "Circle2")
            {
                for (int i = 0; i < Global.Objects.Count; i++)
                {
                    if (Global.Objects[i].Name != Name)
                    {
                        float Distance = CustomFunctions.VectorDistance(Pos, Global.Objects[i].Pos);
                        float AtForce = (float)(6.67d * 2048 * 10000) * Mass * Global.Objects[i].Mass / (float)Math.Pow(CustomFunctions.VectorDistance(Global.Objects[i].Pos, Pos), 2);
                        Vector2f FClamp = CustomFunctions.VectorNormalized(new Vector2f(Global.Objects[i].Pos.X - Pos.X, Global.Objects[i].Pos.Y - Pos.Y));
                        Vector2f Attr = new Vector2f(FClamp.X * AtForce, FClamp.Y * AtForce);
                        if (FindForceIndexByName("Attraction") == -1)
                        {
                            AddForce(Attr, -1, "Attraction");
                        }
                        else
                        {
                            Forces[FindForceIndexByName("Attraction")].Vector = Attr;
                        }
                        //Console.WriteLine(Attr);
                    }
                }
            }
        }
        public void SolveCollision(RenderWindow app)
        {
            //Console.WriteLine(Pos);
            for (int i = 0; i < Global.Objects.Count; i++)
            {

                if (Global.Objects[i].Type == "rect")
                {
                    SolveColWithRect(i, app);
                }
                else
                {
                    PhysicalObject ShapeCol = Global.Objects[i];
                    if (ShapeCol.Radius + Radius > CustomFunctions.VectorDistance(Pos, ShapeCol.Pos) && ShapeCol.Index != Index)
                    {
                        if (ShapeCol.Pos == Pos)
                        {
                            ShapeCol.Pos.X -= Radius / 2;
                            Pos.X += Radius / 2;
                        }
                        else
                        {
                            float KEofCollider = ShapeCol.Mass * CustomFunctions.VectorMagnitude(ShapeCol.Speed) * CustomFunctions.VectorMagnitude(ShapeCol.Speed) * 0.5f;
                            float KEofShape = Mass * CustomFunctions.VectorMagnitude(Speed) * CustomFunctions.VectorMagnitude(Speed) * 0.5f;
                            //Console.WriteLine((KEofCollider + KEofShape));

                            float DistanceToMove = (CustomFunctions.VectorDistance(Pos, ShapeCol.Pos) - (ShapeCol.Radius + Radius)) / 2;


                            List<Vector2f> Speeds = CalculateSpeeds(Global.Objects[CustomFunctions.FindObjectByName(SystemName)], ShapeCol);

                            Speed = Speeds[0];
                            ShapeCol.Speed = Speeds[1];

                            Pos = new Vector2f(DistanceToMove * CustomFunctions.VectorNormalized(CustomFunctions.Direction(Pos, ShapeCol.Pos)).X + Pos.X, DistanceToMove * CustomFunctions.VectorNormalized(CustomFunctions.Direction(Pos, ShapeCol.Pos)).Y + Pos.Y);
                            ShapeCol.Pos = new Vector2f(DistanceToMove * CustomFunctions.VectorNormalized(CustomFunctions.Direction(ShapeCol.Pos, Pos)).X + ShapeCol.Pos.X, DistanceToMove * CustomFunctions.VectorNormalized(CustomFunctions.Direction(ShapeCol.Pos, Pos)).Y + ShapeCol.Pos.Y);



                            KEofCollider = ShapeCol.Mass * CustomFunctions.VectorMagnitude(ShapeCol.Speed) * CustomFunctions.VectorMagnitude(ShapeCol.Speed) * 0.5f;
                            KEofShape = Mass * CustomFunctions.VectorMagnitude(Speed) * CustomFunctions.VectorMagnitude(Speed) * 0.5f;
                            //Console.WriteLine((KEofCollider + KEofShape));

                            Global.Objects[i] = ShapeCol;
                        }
                    }
                }
            }
        }
        public List<Vector2f> CalculateSpeeds(PhysicalObject Obj1, PhysicalObject Obj2)
        {
            Vector2f pos1 = Obj1.Pos;
            Vector2f pos2 = Obj2.Pos;
            Vector2f vel1 = Obj1.Speed;
            Vector2f vel2 = Obj2.Speed;
            float mass1 = Obj1.Mass;
            float mass2 = Obj2.Mass;

            Vector2f n = CustomFunctions.VectorNormalized(pos2 - pos1);
            Vector2f relativeVelocity = vel2 - vel1;

            float vRelAlongNormal = CustomFunctions.VectorsDot(relativeVelocity, n);

            if (vRelAlongNormal < 0)
            {
                float e = 1f;

                float j = -(1 + e) * vRelAlongNormal;
                j /= 1 / mass1 + 1 / mass2;

                Vector2f impulse = j * n;
                vel1 -= 1 / mass1 * impulse;
                vel2 += 1 / mass2 * impulse;
            }

            List<Vector2f> Result = new List<Vector2f>() { vel1, vel2 };
            return Result;
        }

        public void SolveColWithRect(int Index, RenderWindow app)
        {
            Shape RectShape = Global.Objects[Index].PhysObject;


            Vector2f ClosestPoint1 = Constants.VectorZero, ClosestPoint2 = Constants.VectorZero;
            float CPDist1 = float.PositiveInfinity, CPDist2 = float.PositiveInfinity;
            uint CPIndex1 = 0;


            for (uint i = 0; i < RectShape.GetPointCount(); i++)
            {
                Vector2f PointPos = CustomFunctions.Rotate(RectShape.GetPoint(i) - RectShape.Origin, RectShape.Rotation) + RectShape.Position;
                if (CustomFunctions.VectorDistance(PointPos, Pos) < CPDist1)
                {
                    CPDist1 = CustomFunctions.VectorDistance(PointPos, Pos);
                    ClosestPoint1 = PointPos;
                    CPIndex1 = i;
                }
            }
            Vector2f PrevPoint = CPIndex1 == 0 ? CustomFunctions.Rotate(RectShape.GetPoint(3) - RectShape.Origin, RectShape.Rotation) + RectShape.Position : CustomFunctions.Rotate(RectShape.GetPoint(CPIndex1 - 1) - RectShape.Origin, RectShape.Rotation) + RectShape.Position;
            Vector2f NextPoint = CPIndex1 == 3 ? CustomFunctions.Rotate(RectShape.GetPoint(0) - RectShape.Origin, RectShape.Rotation) + RectShape.Position : CustomFunctions.Rotate(RectShape.GetPoint(CPIndex1 + 1) - RectShape.Origin, RectShape.Rotation) + RectShape.Position;

            if(CustomFunctions.VectorDistance(Global.Objects[Index].Pos, CustomFunctions.CalculateCross(Global.Objects[Index].Pos, Pos, ClosestPoint1, PrevPoint)) < CustomFunctions.VectorDistance(Global.Objects[Index].Pos, CustomFunctions.CalculateCross(Global.Objects[Index].Pos, Pos, ClosestPoint1, NextPoint)))
            {
                ClosestPoint2 = PrevPoint;
                CPDist2 = CustomFunctions.VectorDistance(PrevPoint, Pos);
            }
            else
            {
                ClosestPoint2 = NextPoint;
                CPDist2 = CustomFunctions.VectorDistance(NextPoint, Pos);
            }


            float DistBetw = CustomFunctions.VectorDistance(ClosestPoint1, ClosestPoint2);
            float HalfP = (CPDist1 + CPDist2 + DistBetw) * 0.5f;
            float S = (float)Math.Sqrt(HalfP * (HalfP - CPDist1) * (HalfP - CPDist2) * (HalfP - DistBetw));
            float DistanceToSide = (2 * S) / DistBetw;

            if (DistanceToSide < Radius && (DistBetw + Radius > CPDist2 && DistBetw + Radius > CPDist1))
            {
                Vector2f ClosestPoint = Constants.VectorZero, FurthestPoint = Constants.VectorZero;
                Vector2f PointDir = Constants.VectorZero;
                if (CPDist1 < CPDist2)
                {
                    PointDir = CustomFunctions.VectorSubs(ClosestPoint1, ClosestPoint2);
                    ClosestPoint = ClosestPoint1;
                    FurthestPoint = ClosestPoint2;
                }
                else
                {
                    PointDir = CustomFunctions.VectorSubs(ClosestPoint2, ClosestPoint1);
                    ClosestPoint = ClosestPoint2;
                    FurthestPoint = ClosestPoint1;
                }
                PointDir = CustomFunctions.VectorNormalized(PointDir);


                Vector2f PD1 = CustomFunctions.RotateVec90ToLeft(PointDir);
                Vector2f PD2 = CustomFunctions.RotateVec90ToRight(PointDir);

                if (CustomFunctions.VectorDistance(CustomFunctions.VectorSumm(PD1, ClosestPoint), Pos) < CustomFunctions.VectorDistance(CustomFunctions.VectorSumm(PD2, ClosestPoint), Pos))
                {
                    Pos += (Radius - DistanceToSide) * PD1;
                }
                else
                {
                    Pos += (Radius - DistanceToSide) * PD2;
                }


                Speed = CustomFunctions.ReflectVector(Speed, FurthestPoint, ClosestPoint);
            }

        }


        public void SolveForcesTime()
        {
            for (int i = 0; i < Forces.Count; i++)
            {
                if (Forces[i].Time != -1)
                {
                    if (Forces[i].Time <= 0)
                    {
                        RemoveForce(i);
                    }
                    else
                    {
                        Forces[i].Time -= Global.DeltaTime;
                    }
                }
            }
        }
        public void SolveWalls()
        {
            if (Pos.Y + Radius > 600)
            {
                Pos.Y = 600 - Radius;
                Speed.Y *= -1 * Global.YWallEff;
            }
            if (Pos.X + Radius > 800)
            {
                Pos.X = 800 - Radius;
                Speed.X *= -1 * Global.XWallEff;
            }

            if (Pos.Y - Radius < 100)
            {
                Pos.Y = Radius + 100;
                Speed.Y *= -1 * Global.YWallEff;
            }
            if (Pos.X - Radius < 0)
            {
                Pos.X = Radius;
                Speed.X *= -1 * Global.XWallEff;
            }
        }
        public void AddGravity()
        {
            Speed.Y += UseGravity ? Gravity * Global.DeltaTime * 50 : 0;
        }

        public bool CheckMouseOver()
        {
            if (Type != "rect")
            {
                return PhysObject.GetGlobalBounds().Contains(Input.MousePos.X, Input.MousePos.Y);
            }
            else
            {
                List<Vector2f> Vertecies = new List<Vector2f>();
                for(uint i = 0; i < PhysObject.GetPointCount(); i++)
                {
                    Vector2f PointPos = CustomFunctions.Rotate(PhysObject.GetPoint(i) - PhysObject.Origin, PhysObject.Rotation) + PhysObject.Position;
                    Vertecies.Add(PointPos);
                }
                return CustomFunctions.IsInside(new Vector2f(Input.MousePos.X, Input.MousePos.Y), Vertecies);
            }
        }
        public void HighLight()
        {
            if(CheckMouseOver() || Index == Global.SelectedID)
            {
                PhysObject.OutlineThickness = Radius/5;
            }
            else
            {
                PhysObject.OutlineThickness = 0;
            }

            if(CheckMouseOver() && Index != Global.SelectedID)
            {
                PhysObject.OutlineColor = Color.Cyan;
            }
            else if(Index == Global.SelectedID)
            {
                PhysObject.OutlineColor = Color.Blue;
            }
        }
    }

    class Force
    {
        public Vector2f Vector;
        public float Time;
        public string Name;
        public int Index;
    }

    class Button
    {
        public RectangleShape BTTN = new RectangleShape();
        public string Text = "";
        public Vector2f Pos = Constants.VectorZero;
        public Vector2f Size = Constants.VectorZero;
        public Color MainColor = Color.White;
        public Color HighlightColor = Color.Yellow;
        public string Name;
        public int Index;
        public ExtraFunc Func;
        public bool Active = true;

        public bool CheckMouseOver()
        {
            return BTTN.GetGlobalBounds().Contains(Input.MousePos.X, Input.MousePos.Y);
        }
        public void Init()
        {
            BTTN.Size = Size;
            BTTN.Position = Pos;
            BTTN.FillColor = CheckMouseOver() ? HighlightColor : MainColor;
        }
        public void Draw(RenderWindow Window)
        {
            Window.Draw(BTTN);
        }
        public bool CheckPressed()
        {
            return (Input.MouseLeft && CheckMouseOver());
        }
    }
    //End Program
}
//To Here