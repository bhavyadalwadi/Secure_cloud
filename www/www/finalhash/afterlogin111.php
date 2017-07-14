
<!doctype html>
<?php
session_start();
if($_SESSION['email'] == NULL)
{
header("location:login111.html");
}

$conn=mysql_connect("localhost","root","") or die(mysql_error());
$sdb=mysql_select_db("project_database",$conn) or die(mysql_error());
if(isset($_POST['submit'])!=""){
  $name=$_FILES['photo']['name'];
  $size=$_FILES['photo']['size'];
  $type=$_FILES['photo']['type'];
  $temp=$_FILES['photo']['tmp_name'];
  $caption1=$_POST['caption'];
  $link=$_POST['link'];
  move_uploaded_file($temp,"files/".$name);
$insert=mysql_query("insert into upload(name)values('$name')");
if($insert){
header("location:ind.php");
}
else{
die(mysql_error());
}
}
?>





<html>
<head>
<meta charset="utf-8">
<!-- TemplateBeginEditable name="doctitle" -->
<title>Qr login</title>
<!-- TemplateEndEditable -->
<!-- TemplateBeginEditable name="head" -->
<!-- TemplateEndEditable -->
<style type="text/css">
<!--
html {
	height: 100%;
}

body {
	height: 100%;
	font: 100%/1.4 Verdana, Arial, Helvetica, sans-serif;
	background-color: #D6D6D6;
	margin: 0;
	padding: 0;
	color: #000;


}
/* ~~ Element/tag selectors ~~ */
ul, ol, dl { /* Due to variations between browsers, it's best practices to zero padding and margin on lists. For consistency, you can either specify the amounts you want here, or on the list items (LI, DT, DD) they contain. Remember that what you do here will cascade to the .nav list unless you write a more specific selector. */
	padding: 0;
	margin: 0;
}
h1, h2, h3, h4, h5, h6, p {
	margin-top: 0;	 /* removing the top margin gets around an issue where margins can escape from their containing div. The remaining bottom margin will hold it away from any elements that follow. */
	padding-right: 15px;
	padding-left: 15px; /* adding the padding to the sides of the elements within the divs, instead of the divs themselves, gets rid of any box model math. A nested div with side padding can also be used as an alternate method. */
}
a img { /* this selector removes the default blue border displayed in some browsers around an image when it is surrounded by a link */
	border: none;
}

/* ~~ Styling for your site's links must remain in this order - including the group of selectors that create the hover effect. ~~ */
a:link {
	color: #42413C;
	text-decoration: underline; /* unless you style your links to look extremely unique, it's best to provide underlines for quick visual identification */
}
a:visited {
	color: #6E6C64;
	text-decoration: underline;
}
a:hover, a:active, a:focus { /* this group of selectors will give a keyboard navigator the same hover experience as the person using a mouse. */
	text-decoration: none;
}
#file{float:inherit;
	width: 500px;
	min-height: 765px;
	background-color: #D6D6D6;
	margin: auto;
	alignment-adjust:central;
	
	}

.header {
	background-color: #ADB96E;
}

.sidebar1 {
	float: left;
	width: 180px;
	min-height: 765px;
	background-color: #EADCAE;
	margin: auto;

}
.content {

	padding: 10px 0;
	width: 780px;
	float: left;
}

/* ~~ This grouped selector gives the lists in the .content area space ~~ */
.content ul, .content ol { 
	padding: 0 15px 15px 40px; /* this padding mirrors the right padding in the headings and paragraph rule above. Padding was placed on the bottom for space between other elements on the lists and on the left to create the indention. These may be adjusted as you wish. */
}

/* ~~ The navigation list styles (can be removed if you choose to use a premade flyout menu like Spry) ~~ */
ul.nav {
	list-style: none; /* this removes the list marker */
	border-top: 1px solid #666; /* this creates the top border for the links - all others are placed using a bottom border on the LI */
	margin-bottom: 15px; /* this creates the space between the navigation on the content below */
}
ul.nav li {
	border-bottom: 1px solid #666; /* this creates the button separation */
}
ul.nav a, ul.nav a:visited { /* grouping these selectors makes sure that your links retain their button look even after being visited */
	padding: 5px 5px 5px 15px;
	display: block; /* this gives the link block properties causing it to fill the whole LI containing it. This causes the entire area to react to a mouse click. */
	width: 160px;  /*this width makes the entire button clickable for IE6. If you don't need to support IE6, it can be removed. Calculate the proper width by subtracting the padding on this link from the width of your sidebar container. */
	text-decoration: none;
	background-color: #C6D580;
}
ul.nav a:hover, ul.nav a:active, ul.nav a:focus { /* this changes the background and text color for both mouse and keyboard navigators */
	background-color: #ADB96E;
	color: #FFF;
}

/* ~~ The footer ~~ */
.footer {
	padding: 10px 0;
	background-color: #CCC49F;
	position: relative;/* this gives IE6 hasLayout to properly clear */
	clear: both; /* this clear property forces the .container to understand where the columns end and contain them */
}

/* ~~ miscellaneous float/clear classes ~~ */
.fltrt {  /* this class can be used to float an element right in your page. The floated element must precede the element it should be next to on the page. */
	float: right;
	margin-left: 8px;
}
.fltlft { /* this class can be used to float an element left in your page. The floated element must precede the element it should be next to on the page. */
	float: left;
	margin-right: 8px;
}
.clearfloat { /* this class can be placed on a <br /> or empty div as the final element following the last floated div (within the #container) if the #footer is removed or taken out of the #container */
	clear:both;
	height:0;
	font-size: 1px;
	line-height: 0px;
}
-->
</style>

<style type="text/css">
            html, body { margin: 0; padding: 0; height: 100%; }

        	#outer {height: 100%; overflow: hidden; position: relative; width: 100%;}
        	#outer[id] {display: table; position: static;}

        	#middle {position: absolute; top: 50%; width: 100%; text-align: center;}
        	#middle[id] {display: table-cell; vertical-align: middle; position: static;}

        	#inner {position: relative; top: -50%; text-align: left;}
        	#inner {margin-left: auto; margin-right: auto;}
            #inner {width: 300px; } /* this width should be the width of the box you want centered */
        body {}
</style>



</head>

<body>




<div class="container">
  <div class="header"><a href="#"><img src="bk/qr.png" alt="Insert Logo Here" name="Insert_logo" width="181" height="191" id="Insert_logo" style="background-color: #C6D580; display:block;" /></a> 
    <!-- end .header --></div>
<div class="sidebar1">
    <ul class="nav">
	  <li><a href="#">Home</a></li>
      <li><a href="logout.php">Logout</a></li>
      <li><a href="#">About Us</a></li>
    </ul>
    <p>&nbsp;</p>
    <FONT SIZE="4" FACE="Courier New, Courier, monospace" COLOR=blue><marquee behavior="scroll" direction="up" align="middle" scrollamount="3">&quot;we provide you <br> a service on which <br> you can trust....&quot;</p> </marquee></font>

</div>

<div id="file">
	<?php
//echo $_SESSION['email'];
?>

<center>
<h1>CLICK TO DOWNLOAD</h1>
<table border="1" id="table1" cellpadding="0" cellspacing="0">
<tr><th width="300">FILE</th><th width="300">SESSION KEY</th></tr>
<?php
$count=0;
$select = mysql_query("select * from userfile where email='".$_SESSION['email']."'");
while($row1=mysql_fetch_array($select)){
		
	if($count==0)
	{
	$name=$row1['filename'];
?>

<?php
	$lenn = strlen($name);
	$n = strpos($name,'.',$lenn-4);
	$keyfile = substr($name, 0,$n) . "Key" . substr($name, $n);
?>
<tr>
<td>
<a href="download.php?filename=<?php echo $name;?>"><?php echo $name;?></a>
</td>
<td>
<a href="download.php?filename=<?php echo $keyfile;?>"><?php echo "KEY";?></a>
</td>
</tr>
<?php
	$count=1;
	}
	else
	{$count=0;}
}
?>
</body>
</html>
	
  <div class="content">
    <h1>&nbsp;</h1>
    <!-- end .content --></div>
  
  <!-- end .container --></div>

</div>

</table>

</center>
</div>
</body>
</html>
