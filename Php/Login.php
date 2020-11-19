<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app
// $loginEmail = $_POST['loginEmail']; // Fill this variable from Unity
// $plainPassUnity = $_POST['loginPass']; // Fill with plain password

// Get data
$result = $conn->DbSelect('*', 'students', "email='{$loginEmail}'");

// $result = $conn->DbSelect('*', 'students', 'email = "s@l.com"');


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

$conn->DbClose();

?>