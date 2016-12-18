function download(uri) {
	$.ajax({
		url: uri,
		method:'GET',
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

function downloadImage(uri) {
	$.ajax({
		method: "GET",
		url: uri,
		headers: {
			'Content-Type': "image/jpeg"
		},
		success: function (data) {
			$('p#image img').attr('src', data);
		},
		error: function() {
			setStatus("There is no image you try to download from: " + uri, "alert-danger");
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
		$("p#" + key.toLowerCase()).html(propertyName + value);
	});

	var downloadImageLink = $.grep(data.Links, function (item) {
		return item.Rel == "download-image";
	})[0];

	$('p#image span').click(function() {
		downloadImage(downloadImageLink.Href);
	});
}