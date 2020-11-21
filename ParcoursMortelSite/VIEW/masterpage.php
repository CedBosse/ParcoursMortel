<?php
  include __DIR__ . "/../UTILS/moduleloader.php";
?>

<!DOCTYPE HTML>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">   
        <script type='text/javascript' src='./SCRIPT/pfi.js'></script>
        <?php include "bootstrap.html";?>
        <title> <?php echo $title ?> </title>
    </head>
    <body style="">
        <?php include "navigationmodule.php";?>
        <div class="">
            <?php  load_modules($content); ?>
        </div>       
       <footer class="mt-5">         
                 
        </footer>
    </body>
</html>
