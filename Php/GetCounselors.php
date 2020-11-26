<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Get all counselors
$counselors = $conn->DbSelect('*', 'counselors');

if ($counselors->num_rows > 0) {
    // output data of each row
    while($row = $counselors->fetch_assoc()) {
      $return["id"] = $row["id"];
      $return["first_name"] = $row["first_name"];
      $return["last_name"] = $row["last_name"];
      
      echo json_encode($return);
    }
  } else {
    echo "0 results";
  }

  $conn->DbClose();

?>