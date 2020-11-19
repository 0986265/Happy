<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Variables from user app
$studentId = $_POST['studentId']; // Fill this variable from Unity
$avatarId = $_POST['avatarId']; // Fill this variable from Unity

// Update data
$update = "avatar='{$avatarId}'";
$where_claus = "id={$studentId}";

if($conn->DbUpdate('students', $update, $where_claus)){
  echo "Avatar updated";
}else{
  echo "Avatar update failed";
}

$conn->DbClose();

?>