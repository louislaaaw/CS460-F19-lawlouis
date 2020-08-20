$().ready(function () {
    var source = '/api/user';
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: displayUser,
        error: errorOnAjax
    });
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'api/repositories',
        success: displayRepo,
        error: errorOnAjax
    });
})

/*function RetrieveCommits(user, repo){
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'api/commits?user=' + user + '&repo=' + repo,
        success: displayCommit,
        error: errorOnAjax
    })
})*/

function errorOnAjax() {
    console.log('Error on AJAX return');
}

function displayUser(data) {
    console.log(data);
    $('#name').text(data.Name);
    $('#username').text(data.Username);
    $('#email').text(data.Email);
    $('#company').text(data.Company);
    $('#location').text(data.Location);
    $('#image').attr("src", data.AvatarURL);
    $('#gitlink').attr("href", data.URL);
}

function displayRepo(data) {
    console.log(data);
    for (i = 0; i < data.length; i++) {
        $('<div class="jumbotron">' +
            '<div class="row">' +
                '<div class="col-lg-2">' +
                '<img src="' + data[i].AvatarUrl + '" width="100px" height="100px" />' +
                '</div>' +
                '<div class="col-lg-3">' +
                    '<a href="' + data[i].URL + '">' + '<h3>' + data[i].Name + '</h3>' + '</a>' +
                    '</br>' + data[i].Owner +
                    '</br>' + 'Last updated ' + data[i].LastUpdated + ' days ago' +
                    '<p><a class="btn btn-primary btn-lg" id="repo' + i + '">Show Commit</a></p>' +
                '</div>' +
            '</div>' +
           '</div>').appendTo('#repo');
    }
}

/*function displayCommit(data) {

}*/