<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app
$studentId = $_POST['studentId']; // Fill this variable from Unity

// Update data
$update = "active=1";
$where_claus = "id={$studentId}";

if($conn->DbUpdate('students', $update, $where_claus)){
  echo "Student is active";
}else{
  echo "Couldn't activate student";
}

$conn->DbClose();

?>