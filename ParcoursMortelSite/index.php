<?php
    session_start();
    include "UTILS/sessionhandler.php";


    //load view content
    $module = "indexview.php";
    $content = array();
    array_push($content, $module);

    //variables used in the loaded module
    $title = "Index";

    //load the masterpage
    require_once __DIR__ . "/VIEW/masterpage.php";

?>