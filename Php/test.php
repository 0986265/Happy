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
echo "Connected successfully";
}


// Get data
$sql = "SELECT first_name, last_name FROM students";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      echo "First name: " . $row["first_name"]. "Last name:  " . $row["last_name"];
    }
  } else {
    echo "0 results";
  }

  $conn->close();

?>