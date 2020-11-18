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
}

// Variables from user app
$loginEmail = htmlentities($_POST['loginEmail']); // Fill this variable from Unity
$plainPassUnity = htmlentities($_POST['loginPass']); // Fill with plain password

// Get data
$sql = "SELECT * FROM students WHERE email = '" . $loginEmail . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      if (password_verify($plainPassUnity, $row["password"])) {

        $return["id"] = $row["id"];
        $return["firstname"] = $row["first_name"];
        $return["lastname"] = $row["last_name"];
        $return["email"] = $row["email"];
        $return["nickname"] = $row["nickname"];

        echo json_encode($return);
      } else {
        echo "Wrong credentials";
      }
    }
} else {
  echo "Email does not exist";
}

$conn->close();

?>