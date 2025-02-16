using System;

// 1. ExprEval using Operator Overloading
public class ExprEval
{
    private double Val;
    public ExprEval(double val) => Val = val;
    public static ExprEval operator +(ExprEval a, ExprEval b) => new(a.Val + b.Val);
    public static ExprEval operator -(ExprEval a, ExprEval b) => new(a.Val - b.Val);
    public static ExprEval operator *(ExprEval a, ExprEval b) => new(a.Val * b.Val);
    public static ExprEval operator /(ExprEval a, ExprEval b) => new(a.Val / b.Val);
    public override string ToString() => Val.ToString();
}

// 2. DBConnector with Derived Classes
public abstract class DBConnector { public abstract void Connect(); }
public class SQL : DBConnector { public override void Connect() => Console.WriteLine("Connected to SQL DB."); }
public class MongoDB : DBConnector { public override void Connect() => Console.WriteLine("Connected to MongoDB."); }
public class Firebase : DBConnector { public override void Connect() => Console.WriteLine("Connected to Firebase."); }

// 3. Compressor with Method Overloading
public class Compressor
{
    public void Compress(string text) => Console.WriteLine("Compressing text...");
    public void Compress(byte[] image) => Console.WriteLine("Compressing image...");
    public void Compress(string video, int bitrate) => Console.WriteLine($"Compressing video at {bitrate} bitrate...");
}

// 4. AIModel with Method Overriding
public abstract class AIModel { public abstract void Train(); }
public class BasicAI : AIModel { public override void Train() => Console.WriteLine("Training Basic AI..."); }
public class NeuralNet : AIModel { public override void Train() => Console.WriteLine("Training Neural Network..."); }
public class DeepLearning : AIModel { public override void Train() => Console.WriteLine("Training Deep Learning..."); }

// 5. PhysicsEngine with 2D and 3D Implementations
public abstract class PhysicsEngine { public abstract void Apply(); }
public class Physics2D : PhysicsEngine { public override void Apply() => Console.WriteLine("Applying 2D Physics..."); }
public class Physics3D : PhysicsEngine { public override void Apply() => Console.WriteLine("Applying 3D Physics..."); }

// Main Program
// class Program
// {
//     static void Main()
//     {
//         // ExprEval Test
//         var n1 = new ExprEval(10);
//         var n2 = new ExprEval(5);
//         Console.WriteLine("Add: " + (n1 + n2));
//         Console.WriteLine("Multiply: " + (n1 * n2));

//         // DBConnector Test
//         new SQL().Connect();
//         new MongoDB().Connect();
//         new Firebase().Connect();

//         // Compressor Test
//         var comp = new Compressor();
//         comp.Compress("text data");
//         comp.Compress(new byte[10]);
//         comp.Compress("video.mp4", 720);

//         // AIModel Test
//         new BasicAI().Train();
//         new NeuralNet().Train();
//         new DeepLearning().Train();

//         // PhysicsEngine Test
//         new Physics2D().Apply();
//         new Physics3D().Apply();
//     }
// }
