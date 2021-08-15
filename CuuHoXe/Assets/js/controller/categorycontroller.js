$(document).ready(function () {
	$(document).on('click', "button[name='delete']", function () {

		let id = $(this).closest('tr').attr('id');
		console.log('ID = ' + id);
		if (confirm('Bạn có muốn xóa?')) {
			$.post("/admin/category/delete",
			{
				id: id,
			},
			function (result) {
				if (result.code == 200) {
					alert(result.msg);
					location.reload();
				} else {
					alert(result.msg);
					//khoản nó xóa thành công rồi nhưng ko reload lại trang
					// thêm một vài cái đã rồi xóa vì những cái t làm nó liên hệ tới bảng khác nên ko xóa đợc đâu
				}
			});
		}
	});

});
