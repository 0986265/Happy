<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app
$studentId = $_POST['studentId']; // Fill this variable from Unity

// Get data
$result = $conn->DbSelect('*', 'appointments', "student_id='{$studentId}'");

$array = [];

if ($result->num_rows > 0) {
    // output data of each row
    $i = 0;
    while($row = $result->fetch_assoc()) {
        $return["id"] = $row["id"];
        $return["student_id"] = $row["student_id"];
        $return["counselor_id"] = $row["counselor_id"];
        $return["appointment_date"] = $row["appointment_date"];
        $return["attending"] = $row["attending"];
        $return["subject"] = $row["subject"];
        array_push($array, $return);
      }
} else {
  echo "There are no appointments for this user";
}

header('Content-Type: application/json');
echo json_encode($array);

$conn->DbClose();