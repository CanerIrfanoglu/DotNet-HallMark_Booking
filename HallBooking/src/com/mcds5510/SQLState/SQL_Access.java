package com.mcds5510.SQLState;

import java.sql.*;

import com.mcds5510.connectDB.*;
import com.mcds5510.entity.login.*;

public class SQL_Access {  
	
	public boolean check_Login(Login_Data login) throws ClassNotFoundException, SQLException
	{
		SQLServerConnection mycon=SQLServerConnection.getObject();
		Connection con=mycon.getConnection();
		Statement stmt = con.createStatement();
		ResultSet res = stmt.executeQuery("SELECT * FROM user_login where username='"+login.getUserName()+"' and password='"+login.getPassword()+"'");
		if (res.next()) return true;
		else 			return false;
	}

}
