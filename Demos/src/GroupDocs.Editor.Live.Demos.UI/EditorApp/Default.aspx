<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocs.Editor.Live.Demos.UI.EditorApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myApp" style="height: 100%; overflow-y: hidden;">
<head runat="server">

	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width" />

	<title>GroupDocs HTML Editor App</title>

	<link href="/favicon.ico" rel="shortcut icon" type="image/vnd.microsoft.icon" />

	<script src="/EditorApp/qi/doc/js/custom.js?v1.6"></script>
	<script>
		fileName = '<%= fileName%>';
		folderName = '<%= folderName%>';
	</script>


	<link href="/qi/css/addon/effect-light.min.css" rel="stylesheet" />
	<link href="/qi/css/quantumui.min.css?v1.1" rel="stylesheet" />
	<link href="/qi/css/docstyle.css?v1.3" rel="stylesheet" />
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/moment.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular-sanitize.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular-animate.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular-resource.min.js"></script>
	<script src="/qi/js/quantumui-all.min.js?v1.0"></script>
	<script src="/qi/config/icons.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js"></script>
	<script src="https://netdna.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.js"></script>
	<link href="/EditorApp/summernote/dist/summernote.css?v1.1" rel="stylesheet">
	<script src="/EditorApp/summernote/dist/summernote.js"></script>
	<script src="/EditorApp/qi/doc/js/app.js?v2.5"></script>

	<% if (Request.Url.AbsoluteUri.Contains("://products.groupdocs.app"))
		{ %>
	<!-- Only track live pages in Google Analytics -->
	<!-- Global site tag (gtag.js) - Google Analytics -->
	<script async src="https://www.googletagmanager.com/gtag/js?id=UA-27946748-4"></script>
	<script>
		window.dataLayer = window.dataLayer || [];
		function gtag() { dataLayer.push(arguments); }
		gtag('js', new Date());

		gtag('config', 'UA-27946748-4');
	</script>
	<% } %>
</head>
<body oncontextmenu="return true" data-ng-controller="EditorAPIController" style="height: 100vh; overflow: hidden!important;">
	<form id="form1" runat="server">
		<header>
			<div class="navbar navbar-inverse navbar-fixed-top" style="margin: 0; background-color: #131313!important;">
				<div class="container-fluid" style="padding-right: 5px!important;">
					<div class="navbar-header-right" style="color: #fff;">
						<button type="button" class="navbar-toggle" data-nq-collapse="" data-target-id=".navbar-collapse">
							<span class="sr-only">Toggle navigation</span>
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
						</button>
					</div>
					<div class="navbar-header">
						<a class="navbar-brand" href="#" style="padding: 5px 15px;">
							<img src="/images/GroupDocs-logo.png" alt="GroupDocs Editor App" />
						</a>
						<a class="navbar-brand with-logo" href="#" style="position: relative;">
							<h5 style="padding-top: 7px; color: #fff">HTML Editor</h5>
						</a>
					</div>
					<div class="navbar-collapse collapse">
						<div class="nav navbar-nav navbar-right" style="height: 45px;">
							<button type="button" data-nq-modal-box="" data-box-type="confirm" class="navbar-toggle titip-left" data-after-confirm="existApp(true)" data-qs-content="<p><b>Are you sure, you want to close and exit the <i>GroupDocs Editor Application</i>?</b><br /><br /><br /><b>Note:</b><i> All changes will be discarted.</i></p>" data-title="Close" style="border: none!important;">
								<i class="glyphicon glyphicon-remove"></i>
							</button>
						</div>
						<ul class="nav navbar-nav navbar-right" style="display: block;">
							<li>
								<button type="button" data-title="Downloads" role="button" data-nq-dropdown="" class="navbar-toggle titip-left" style="border: none!important;" data-qo-placement="bottom-right">
									<i class="glyphicon glyphicon-download-alt"></i><span class="caret"></span>
								</button>
								<ul class="dropdown-menu" tabindex="-1" role="menu">
									<li role="presentation"><a role="menuitem" tabindex="-1" target="_blank" ng-click="updateContents()" ng-href="/GroupDocsapi/api/GroupDocsEditor/downloaddocument?file=<%= fileName%>&folderName=<%= folderName%>&isUpdated=true"><i class="glyphicon glyphicon-download-alt"></i>&nbsp;Download</a></li>
									<li role="presentation"><a role="menuitem" tabindex="-1" target="_blank" ng-click="updateContents()" ng-href="/GroupDocsapi/api/GroupDocsViewer/downloadpdfdocument?file=Updated_<%= fileName%>&folderName=<%= folderName%>"><i class="glyphicon glyphicon-download-alt"></i>&nbsp;Download As PDF</a></li>
									<li role="presentation"><a role="menuitem" tabindex="-1" target="_blank" ng-href="/GroupDocsapi/api/GroupDocsEditor/downloaddocument?file=<%= fileName%>&folderName=<%= folderName%>&isUpdated=false"><i class="glyphicon glyphicon-download-alt"></i>&nbsp;Download Original</a></li>
								</ul>
							</li>
						</ul>

						<div class="nav navbar-nav navbar-right" style="color: #fff; padding-right: 5px;">
							<ul class="nav navbar-nav navbar-left">
								<li>
									<div style="margin-top: 15px;"><b>File:</b> <%= fileName%></div>
								</li>
							</ul>
						</div>
						<div class="nav navbar-nav navbar-left" style="height: 45px; padding-left: 1%;">
							<button id="btnSave" type="button" class="navbar-toggle titip-left" ng-click="updateContents()" style="border: none!important;">
								<i class="glyphicon glyphicon-edit"></i>&nbsp;Save
							</button>
						</div>
					</div>
				</div>
			</div>
		</header>
		<div name="dvPages" class="content-wrapper" style="height: 100vh; padding-top: 55px!important; width: 100%!important; overflow: hidden!important; background: #fff; background-image: url('/images/loader.gif'); background-repeat: no-repeat; background-position: center;">
			<div class="container-fluid" style="padding-left: 0px!important; padding-right: 0px!important; margin-left: 0px!important; margin-right: 0px!important;">
				<div class="clearfix">
					<div class="row">
						<ul class="col-sm-12">
							<li name="dvInnerPages" style="padding-top: 50px!important; display: inline-block; position: fixed; height: auto; width: 100%;">
								<div id="mytextarea" style="padding: 0px 5px 0px 5px !important;"></div>
							</li>
						</ul>
					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
