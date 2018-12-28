
public class Main {

	public static void main(String[] args) {


		int addition = add(2,3);
		System.out.println("addition of numbers:" + addition);
		System.out.println("Max is:" + Max(44,55));
		System.out.println("Min is:" + Min(123,12));
		
		int multiplication  = Mul(4,5);
		System.out.println("Multiplication of numbers:" + multiplication);
		
		int mod = mod(9,3);
		System.out.println("Modulus of numbers:" + mod);
		
		
	}

	public static int add (int a, int b) {
			return a+b;
		}


		

		public int Sub(int x, int y) {
			int z=x-y;
			return z;
		}
		
	 
	
	public static int Mul ( int a, int b) {
		
		return a*b ; 
	}
	
	public static int mod(int a, int b) {
		
		return a%b;
	}
	
	public static int Max (int a, int b)
	{
		return Math.max(a,b);
	}
	
	public static int Min (int a, int b)
	{
		return Math.min(a,b);
	}
}
