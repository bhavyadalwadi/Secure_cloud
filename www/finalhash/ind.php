<?php
session_start();

/**
 PHP API for Login, Register, Changepassword, Resetpassword Requests and for Email Notifications.
 **/
include 'DB_Functions.php';
$db = new DB_Functions();
    // response Array

$email = $_POST['email'];
$password = $_POST['password'];

$no_of_users = mysql_query("SELECT * FROM users WHERE email = '$email'") or die(mysql_error());

        // check for user
        $result = $db->getUserByEmailAndPassword($email, $password);
		// got the result in array form
		
		//$result_string=array($result);
		
		//echo $result;
		
		//$compare=strcmp($password,$result_string);
        
		if ($result != true ) 
        {
		die(mysql_error());
		$count=0;
		}
		else 
		{
			$count = mysql_num_rows($no_of_users);
		}

    if($count==1)
	{
		session_start();
		$_SESSION['email']= $email;
		echo $_SESSION['email'];
		header('location:afterlogin111.php');
	}     
		else 
	{?>
      <html>
	  <body>
	  <h1>INVALID</h1>
	  </body>
	  </html> 
	<?php }
	

?>
