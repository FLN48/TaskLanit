// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Set the width of the side navigation to 250px and the left margin of the page content to 250px */
var state = false;
function openNav() {
    var IconItem = document.getElementById("MenuIcon");
    var ContainerBody = document.getElementById("ContainerBody");
    ContainerBody.classList.toggle("LeftPanel_Open");
    IconItem.classList.toggle("change");
    //document.getElementById("main").style.marginLeft = "250px";
}