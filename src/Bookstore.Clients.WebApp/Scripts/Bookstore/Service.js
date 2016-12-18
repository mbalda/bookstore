function download(uri) {
	$.ajax({
		url: uri,
		type:'GET',
		dataType: 'json',
		error: function (request, status, error) {
			setStatus("Something went wrong! Status code: " + request.status + " " + ( error ), "alert-danger");
			$("#details").removeClass().addClass("hidden");
		},

		success: function (results) {
			setStatus("You've got data from: " + uri, "alert-success");
			displayData(results);
			$("#details").removeClass();
		} 

	});
}

function setStatus(message, statusClass) {
	$("div#status p")
		.text(message)
		.removeClass()
		.addClass(statusClass);

}

function displayData(data) {
	$.each(data, function (key, value) {
		var propertyName = "<strong>" + key + ": </strong>";
		$("p#" + key.toLowerCase()).text(propertyName + value);
	});


}