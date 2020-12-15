<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

$studentId = $_POST['studentId'];
$counselorId = $_POST['counselorId'];
$subject = $_POST['subject'];
$message = htmlentities($_POST['message']);
$createdAt = date('Y-m-d'); // Current day (year, month, day)

$explodedCounselor = explode(":", $counselorId);
$counselorId = $explodedCounselor[0];

// $counselorId = 1;
// $studentId = 2;
// $appointmentDate = "\"2029-12-01\""; 

if($conn->DbInsert("appointments", "student_id, counselor_id, subject, message, created_at", "{$studentId}, {$counselorId}, '{$subject}', '{$message}', '{$createdAt}'")){
    echo "Appointment sent";
}else{
    echo "Something went wrong";
}

$conn->DbClose();

?>