package com.mcds5510.emailsmtp;

import java.util.Properties;

import javax.mail.Authenticator;
import javax.mail.Message;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

public class Send_Email {
	
	public boolean SendEmail(String EmailID, String tomessage)
	{
		try{
	         final String fromEmail = "mani.santhamohan@gmail.com"; //requires valid gmail id
	         final String password = "getVISA@CAN"; // correct password for gmail id
	         final String toEmail = EmailID; // can be any email id 

	         System.out.println("TLSEmail Start");
	         Properties props = new Properties();
	         props.put("mail.smtp.host", "smtp.gmail.com"); //SMTP Host
	         props.put("mail.smtp.port", "587"); //TLS Port
	         props.put("mail.smtp.auth", "true"); //enable authentication
	         props.put("mail.smtp.starttls.enable", "true"); //enable STARTTLS

	             //create Authenticator object to pass in Session.getInstance argument
	         Authenticator auth = new Authenticator() {
	             //override the getPasswordAuthentication method
	             protected PasswordAuthentication getPasswordAuthentication() {
	                 return new PasswordAuthentication(fromEmail, password);
	             }
	         };
	         Session session = Session.getInstance(props, auth);

	         MimeMessage message = new MimeMessage(session);
	         message.setFrom(new InternetAddress(fromEmail));
	         message.addRecipient(Message.RecipientType.TO, new InternetAddress(toEmail));

	         System.out.println("Mail Check 2");

	         message.setSubject("Regarding Conference Hall Booking");
	         message.setText(tomessage);

	         System.out.println("Mail Check 3");

	         Transport.send(message);
	         System.out.println("Mail Sent to "+EmailID+" Message "+tomessage);
	         return true;
	     }catch(Exception ex){
	         ex.printStackTrace();
	         return false;
	     }	
}
}
