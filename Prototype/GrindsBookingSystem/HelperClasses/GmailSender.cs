using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using GrindsBookingSystem.HelperClasses;
namespace GrindsBookingSystem
{
    //this code has been taken from the link provided in the week 4 folder for sep module
    //website link : https://sqlpey.com/c%23/solved-how-to-send-emails-using-gmail-smtp-in-c/
    public class GmailSender
    {
        public static void SendEmail(string fromAddress, string fromPassword, string toAddress, string subject, string body)
        {
            // Use the 16-character App Password here sojw droe pwye nero
            string senderPassword = fromPassword;

            var from = new MailAddress(fromAddress, "GrindBookingSys"); // Optional: Set display name
            var to = new MailAddress(toAddress);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, senderPassword)
            };

            using (var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                try
                {
                    smtp.Send(message);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    // Consider more robust error handling, e.g., logging
                }
            }
        }

        public static string GenerateBookingConfirmationEmail(Class c, string name)
        {
            Tutor t = Tutor.GetTutor(Convert.ToInt32(c.TutorID));
            string tName = t.FirstName;
            string tSname = t.Surname;

            return $@"
            <html>
            <body style='font-family: Arial, sans-serif; background-color:#f4f4f4; padding:20px;'>
                <div style='max-width:600px; margin:auto; background:white; padding:20px; border-radius:10px;'>
            
                    <h2 style='color:#2c3e50;'>Grind Booking Confirmation</h2>

                    <p>Hi {name},</p>

                    <p>Your grind has been successfully booked. Here are your class details:</p>

                    <table style='width:100%; border-collapse: collapse;'>
                        <tr>
                            <td><strong>Subject:</strong></td>
                            <td>{c.GetClassSubject()}</td>
                        </tr>
                        <tr>
                            <td><strong>Day:</strong></td>
                            <td>{DayConversions.GetDayString(c.Day)}</td>
                        </tr>
                        <tr>
                            <td><strong>Time:</strong></td>
                            <td>{c.Time}:00</td>
                        </tr>
                        <tr>
                            <td><strong>Room:</strong></td>
                            <td>{c.RoomNo}</td>
                        </tr>
                        <tr>
                            <td><strong>Teacher:</strong></td>
                            <td>{tName} {tSname}</td>
                        </tr>
                    </table>

                    <br/>

                    <p style='color:#27ae60;'><strong>Please arrive 5 minutes early.</strong></p>

                    <p>If you have any questions, contact the office.</p>

                    <hr/>

                    <p style='font-size:12px; color:gray;'>This is an automated message from the Grind Booking System.</p>
                </div>
            </body>
            </html>";
        }
    }

}
