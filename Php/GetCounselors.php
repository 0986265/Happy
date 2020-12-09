<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Initiate an array to hold all value
$counselor_array = [];

// Get all counselors
$counselors = $conn->DbSelect('*', 'counselors');

if ($counselors->num_rows > 0) {
    // output data of each row
    while($row = $counselors->fetch_assoc()) {
      $return["id"] = $row["id"];
      $return["name"] = $row["first_name"] . ' ' .  $row["last_name"];

      // echo json_encode($return);
      
      // push to array
      array_push($counselor_array, $return);
    }
  } else {
    echo "0 results";
  }

  // Set content type for better readability
  header('Content-Type: application/json');
  echo json_encode($counselor_array);

  $conn->DbClose();

?>