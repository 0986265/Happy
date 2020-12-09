<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app
$appointmentId = $_POST['appointmentId']; // Fill this variable from Unity
$studentId = $_POST['studentId']; // Fill this variable from Unity

// Update data
$update = "attending = 1";
$where_claus = "id={$appointmentId}";

if($conn->DbUpdate('appointments', $update, $where_claus)){
  echo "Attending: accepted";
}else{
  echo "Appointment failed";
}

$conn->DbClose();

?>