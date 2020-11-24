<?php
require 'DatabaseConn.php';

// Create connection
$conn = new DbConn;

// Get all counselors
$counselors = $conn->DbSelect('*', 'counselors');

// foreach($counselors as $counselor){
//     var_dump($counselor);
// }

$counselorId = $_Post['counselorId'];
$studentId = $_Post['studentId'];
$appointmentDate = $_Post['date'];

// $counselorId = 1;
// $studentId = 2;
// $appointmentDate = "\"2029-12-01\""; 

if($conn->DbInsert('appointments', 'student_id, counselor_id, appointment_date', "{$studentId}, {$counselorId}, {$appointmentDate}")){
    echo "Appointment sent";
}else{
    echo "Something went wrong";
}

$conn->DbClose();

?>