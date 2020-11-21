<?php

function generateErrorMSG(){
    $errorMSG = $_GET["ErrorMSG"];
    return "<h4 class='text-light'>$errorMSG</h4></br>";
}

echo "<h2 class='text-light'> Error:", http_response_code(),"</h2>";
echo generateErrorMSG();

?>
