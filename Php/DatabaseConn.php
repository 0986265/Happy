<?php

class DbConn{

    private $servername = "boostworks.online";
    private $username = "boostworksonline_ced-app";
    private $password = "SyoYiTgKYj$6925&aF3y";
    private $db = "boostworksonline_ced";

    function __construct(){
        
        // Create connection
        $conn = new mysqli($servername, $username, $password, $db);

        // Check connection
        if ($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }
    }

}



?>