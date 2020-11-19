<?php

    require 'DatabaseConn.php';

    // Create connection
    $conn = new DbConn;

    // Variables from user app
    // $loginEmail = $_POST['loginEmail']; // Fill this variable from Unity

    // Get data
    // $result = $conn->DbSelect('*', 'students', 'email = "{$loginEmail}"');
    $result = $conn->DbSelect('*', 'students', 'email = "s@l.com"');

    if($result->num_rows > 0){

        while($row = $result->fetch_assoc()){
            /*
            * Set max lenght of the new password
            * Shuffle the string and return a new string with a length of 10
            * Hashed the password with php function
            */ 
            $length = 10;    
            $newPass = substr(str_shuffle('0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ'),0,$length);
            $hashedPass = password_hash($newPass, PASSWORD_DEFAULT, ['cost' => 12]);
        
            $update = "nickname='{$newPass}', password='{$hashedPass}' ";
            $where_claus = "id={$row['id']}";

            if($conn->DbUpdate('students', $update, $where_claus)){
                echo "New passport is {$newPass}";
            }else{
                echo "Password failed";
            }
            
        }
    }else {
        echo "Email does not exist";
    }


?>