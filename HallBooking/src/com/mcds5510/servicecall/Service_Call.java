package com.mcds5510.servicecall;

import java.sql.SQLException;

import com.mcds5510.SQLState.*;
import com.mcds5510.emailsmtp.Send_Email;
import com.mcds5510.entity.login.Login_Data;
public class Service_Call {
	
	public String sendMail(String eMailid, String message)
	{
		
		Send_Email email=new Send_Email();
		boolean result = email.SendEmail(eMailid, message);
		if (result)		return "Mail Sent";
		else 			return "Mail Not Sent";
	}
	
	public boolean checkLogin(String userName,String password) throws ClassNotFoundException, SQLException {
		Login_Data login=new Login_Data();
		login.setUserName(userName);
		login.setPassword(password);
		SQL_Access mySQL=new SQL_Access();
		boolean check=mySQL.check_Login(login);
		return check;
		
	}
}
