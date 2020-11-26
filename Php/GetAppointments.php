<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app
$studentId = $_POST['studentId']; // Fill this variable from Unity
$plainPassUnity = $_POST['loginPass']; // Fill with plain password

// Get data
$result = $conn->DbSelect('*', 'appointments', "student_id='{$studentId}'");

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        $return["id"] = $row["id"];
        $return["student_id"] = $row["student_id"];
        $return["counselor_id"] = $row["counselor_id"];
        $return["appointment_date"] = $row["appointment_date"];
        $return["attending"] = $row["attending"];
        $return["created_at"] = $row["created_at"];
        $return["subject"] = $row["subject"];
        $return["message"] = $row["message"];
        echo json_encode($return);
      }
} else {
  echo "There are no appointments for this user";
}

$conn->DbClose();
