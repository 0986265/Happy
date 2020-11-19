<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Get data
$result = $conn->DbSelect('first_name, last_name', 'students');

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      echo "First name: " . $row["first_name"]. "Last name:  " . $row["last_name"];
    }
  } else {
    echo "0 results";
  }

  $conn->DbClose();

?>