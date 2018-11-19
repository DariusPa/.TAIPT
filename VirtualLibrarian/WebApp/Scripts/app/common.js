$(document).ready(function() {
    $('#search').DataTable();
});

function redirectToDashboard(url) {
    window.location.replace(url);
}

function goToPage(url) {
    window.location.replace('/Dashboard/'+url);
}