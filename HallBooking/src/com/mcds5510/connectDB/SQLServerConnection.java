package com.mcds5510.connectDB;

import java.sql.*;

public class SQLServerConnection {
	
		private static SQLServerConnection my_Connect=new SQLServerConnection();
		
		private SQLServerConnection() {}
		
		public static SQLServerConnection getObject()
		{
			return my_Connect;
		}
		
		public Connection getConnection() throws ClassNotFoundException
		{

        // Create a variable for the connection string.
		
        Connection con=null;
		try {
			Class.forName("com.mysql.jdbc.Driver");
			con = DriverManager.getConnection("jdbc:mysql://localhost:3306/s_manivannan", "s_manivannan", "A00429112");
			return con;
		
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return con; 
		
		}
}
