
<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app
$loginEmail = $_POST['loginEmail']; // Fill this variable from Unity
$plainPassUnity = $_POST['loginPass']; // Fill with plain password

if ($_POST['macAdress'] != null) {
  $macAdress = $_POST['macAdress']; // Fill with student macAdress
}

// Get data
$result = $conn->DbSelect('*', 'students', "email='{$loginEmail}'");

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      if (password_verify($plainPassUnity, $row["password"])) {

        $return["id"] = $row["id"];
        $return["firstname"] = $row["first_name"];
        $return["lastname"] = $row["last_name"];
        $return["email"] = $row["email"];
        $return["nickname"] = $row["nickname"];
        $return["active"] = $row["active"];
        $return["avatar"] = $row["avatar"];
        $return["color"] = $row["color"];

        echo json_encode($return);
      } else {
        echo "Wrong credentials";
      }
    }
} else {
  echo "Email does not exist";
}

// get feelings based on $return["id"]


// pass macAdress to the database
if ($_POST['macAdress'] != null) {
  $result2 = $conn->DbUpdate('students', 'macadress', "email='{$loginEmail}'");

  if ($result2 == false) {
    echo("Something went wrong while sending macadress through the database");
  }
}

$conn->DbClose();

?>