(function () {
	'use strict';

	var app = angular.module('myApp', [
		'ngSanitize',
		'ngAnimate',
		'ngQuantum',
		'ngResource'
	]);

	app.value('PageList', customPageList);

	app.run(['$templateCache', '$cacheFactory',
		function ($templateCache, $cacheFactory) {
			$templateCache = false;
		}]);

	app.config(['$httpProvider',
		function ($httpProvider) {
			$httpProvider.defaults.cache = false;
		}]);

	app.config(['$rootScopeProvider',
		function ($rootScopeProvider) {
			$rootScopeProvider.digestTtl(5);
		}]);

	app.factory('EditorPropertyFactory', function ($resource) {
		return $resource(apiURL + '/api/GroupDocsEditor/EditorPageHtml', {}, {
			query: {
				method: 'GET',
				isArray: false
			}
		});
	});

	function GetEditorHtml(EditorPropertyFactory, $scope) {
		$scope.loading.show();

		EditorPropertyFactory.query({
			file: fileName,
			foldername: folderName
		}, function (data) {
			//console.log('data: ' + JSON.stringify(data));
			contentstext = data.OutputType;
			$('#mytextarea').summernote({
				toolbar: [
					['Style', ['style']],
					['Font Name', ['fontname', 'fontsize']],
					['Colors', ['color']],
					['Text', ['bold', 'italic', 'underline', 'strikethrough', 'superscript', 'subscript', 'height', 'clear']],
					['Font Style', ['ul', 'ol']],
					['Tables', ['table']],
					['Paragraph Style', ['paragraph']],
					['Insert', ['hr', 'picture', 'link', 'video']],
					['view', ['codeview', 'help']]],
				placeholder: 'Please wait while loading contents...!',
				tabsize: 1,
				height: "81vh",
				focus: true
			});

			$('#mytextarea').summernote('code', contentstext);
			//console.log(contentstext);
			document.getElementsByName("dvPages")[0].style.cssText = "height: 100vh; width: auto!important; background-color: #fff; background-image: none!important;";
			$scope.loading.hide();
		}, function (error) {
			console.log('errrrrrooooorrrr: ' + JSON.stringify(error));
			alert(error.data.Message);
		});
	}

	app.controller('EditorAPIController',
		function ViewerAPIController($scope, $sce, $http, $resource, $loading, $timeout, $q, $alert, EditorPropertyFactory) {
			var $that = this;

			$scope.EditorProperties = {}

			$scope.loadingButtonSucces = function () {
				return $timeout(function () {
					return true;
				}, 2000);
			};

			$scope.existApp = function (isExit) {
				if (isExit)
					window.location = '/editor/total';
				else
					window.location = '';
			};

			$scope.loading = new $loading({
				busyText: ' Please wait while loading...',
				theme: 'info',
				timeout: false,
				showSpinner: true
			});

			GetEditorHtml(EditorPropertyFactory, $scope);

			$scope.newField = {};
			$scope.editing = 0;

			$scope.editAppKey = function (field) {
				$scope.loading.show();
				$scope.editing = $scope.EditorProperties.indexOf(field);
				$scope.newField = angular.copy(field);
				$scope.loading.hide();
			};

			$scope.saveField = function (txtName) {
				if ($scope.editing !== false) {
					$scope.loading.show();
					lstEditorProperties[$scope.editing].Value = angular.element(document.getElementsByName(txtName)).val();
					$scope.loading.hide();
				}
			};

			$scope.updateContents = function () {
				document.getElementById("btnSave").disabled = true;

				$scope.loading.show();
				//console.log("updateContents:   " + editorInstance.html.get());
				var objXhr = new XMLHttpRequest();
				var mydata = new FormData();
				var currentContents = "";

				currentContents = $('#mytextarea').summernote('code');
				//console.log('currentContents:   ' + currentContents);
				objXhr.open("POST", apiURL + '/api/GroupDocsEditor/UpdateContents?file=' + fileName + '&folderName=' + folderName, false);
				mydata.append("htmlContents", currentContents);
				objXhr.send(mydata);

				if (objXhr.status === 200) {
					document.getElementById("btnSave").disabled = false;
					//alert('Contents updated successfully.');
				}
				else {
					alert('Unable to update information, please try again.');
				}

				$scope.loading.hide();
				document.getElementById("btnSave").disabled = false;
			};

			$scope.cancel = function (index) {
				if ($scope.editing !== false) {
					$scope.EditorProperties[$scope.editing] = $scope.newField;
					$scope.editing = false;
				}
			};

			$scope.cleanEditor = function (isAll) {
				$scope.loading.show();
				if (isAll) {
					window.location = apiURL + '/api/GroupDocsEditor/CleanEditor?file=' + fileName + '&folderName=' + folderName;
				}
				$scope.loading.hide();
			};

			$scope.exportEditor = function (isExcel) {
				$scope.loading.show();
				window.location = apiURL + '/api/GroupDocsEditor/ExportEditor?file=' + fileName + '&folderName=' + folderName + "&isExcel=" + isExcel;
				$scope.loading.hide();
			};

			$scope.editEditor = function (isAll) {
				$scope.loading.show();
				var objXhr = new XMLHttpRequest();
				var mydata = new FormData();

				objXhr.open("POST", apiURL + '/api/GroupDocsEditor/UpdateEditor?file=' + fileName + '&folderName=' + folderName, false);
				mydata.append("lstProperties", JSON.stringify(lstEditorProperties));
				objXhr.send(mydata);

				if (objXhr.status === 200) {
					window.location = apiURL + '/api/GroupDocsEditor/downloaddocument?file=' + fileName + '&folderName=' + folderName + '&isUpdated=true';
				}
				else {
					alert('Unable to update information, please try again.');
				}

				$scope.loading.hide();
			};

			$scope.getError = function () {
				var deferred = $q.defer();

				setTimeout(function () {
					deferred.reject('Error');
				}, 1000);
				return deferred.promise;
			};

			$scope.displayAlert = function (title, message, theme) {
				$alert(message, title, theme);
			};

			if (customPageList.length <= 0) {
				$scope.PageList = customPageList;
			}
		});
})();