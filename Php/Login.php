<?php
$servername = "boostworks.online";
$username = "boostworksonline_ced-app";
$password = "SyoYiTgKYj$6925&aF3y";
$db = "boostworksonline_ced";

// Create connection
$conn = new mysqli($servername, $username, $password, $db);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
} else {
    // Success message
echo "Connected successfully<br>";
}

// Variables from user app
// $loginEmail = $conn -> real_escape_string($_POST['loginEmail']); // Fill this variable from Unity
// $loginPass = $conn -> real_escape_string($_POST['loginPass']);
$loginEmail = $_POST['loginEmail']; // Fill this variable from Unity
$loginPass = password_hash($_POST['loginPass'], PASSWORD_BCRYPT);
var_dump($loginPass);
// Get data
$sql = "SELECT password FROM students WHERE email = '" . $loginEmail . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      if($row["password"] == $loginPass) {
        echo "Login succeed";
        echo "true";
      } else {
        echo "Wrong credentials";
      }
    }
} else {
  echo "Email does not exist";
}

$conn->close();

?>