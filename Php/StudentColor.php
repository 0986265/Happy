<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app (Unity)
$studentId = $_POST['studentId']; // Fill with unique student ID
$selectedColor = $_POST['selectedColor']; // Fill with color (red, geen, blue, yellow, purple,)

// Update data
$update = "color='{$selectedColor}', active='1'";
$where_claus = "id={$studentId}";

if($conn->DbUpdate('students', $update, $where_claus)){
  echo "Color updated";
}else{
  echo "Color update failed";
}

$conn->DbClose();

?>