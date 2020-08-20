//Did not implement the difference of end of daylight saving time

$('#myform').on("submit", function(event){
    event.preventDefault();
    var user_date = new Date($('#input_time').val());
    var user_timezone = $("select option:selected").text();
    var diff = parseFloat($('#timezone').val());
    var converted_date = new Date(user_date);
    converted_date.setHours(user_date.getHours() + diff);
    $("form").append(`<ul><li>Your Local Time ${user_timezone} is: ${user_date.toLocaleString()}</li><li>Hong Kong(UTC+8) Time is: ${converted_date.toLocaleString()}</li></ul>`);
})

$('#myform').on("reset", function(event){
    $('ul').remove();
})