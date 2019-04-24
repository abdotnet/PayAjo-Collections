(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "../src/$$_lazy_route_resource lazy recursive":
/*!***********************************************************!*\
  !*** ../src/$$_lazy_route_resource lazy namespace object ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "../src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "../src/app/account/account.component.css":
/*!************************************************!*\
  !*** ../src/app/account/account.component.css ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "../src/app/account/account.component.html":
/*!*************************************************!*\
  !*** ../src/app/account/account.component.html ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n    <app-navigation></app-navigation>\n    <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n    <app-topnav></app-topnav>\n    <div class=\"panel-header panel-header-sm panel-header-custom\">\n   </div>\n   <div class=\"content content-custom\">\n    <div class=\"card \">\n      <div class=\"card-header \">\n          <h4 class=\"card-title\">Create User (Agent or Administrator) </h4>\n      </div>\n      <div class=\"card-body \">\n        <div class=\"row\">\n         <div class=\"col-md-6\">\n          <form method=\"#\" action=\"#\">\n              <label>First Name</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"FirstName\" [(ngModel)]=\"user.FirstName\"  class=\"form-control\">\n              </div>\n              <label>Last Name</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"LastName\"  [(ngModel)]=\"user.LastName\" class=\"form-control\">\n              </div>\n              <label>Email Address</label>\n              <div class=\"form-group\">\n                  <input type=\"email\" name=\"EmailAddress\" [(ngModel)]=\"user.EmailAddress\" class=\"form-control\">\n              </div>\n              <label>Address</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"Address\" [(ngModel)]=\"user.Address\" class=\"form-control\">\n              </div>\n              <label>Mobile</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"Mobile\" [(ngModel)]=\"user.Mobile\" class=\"form-control\" autocomplete=\"off\">\n              </div>\n              <label>Username</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"UserId\" [(ngModel)]=\"user.UserName\" class=\"form-control\" autocomplete=\"off\">\n              </div>\n              <label>Gender</label>\n              <select class=\"form-control form-control-sm\" name=\"gender\" [(ngModel)]=\"user.Gender\">\n                <option selected=\"selected\" value=\"Male\">\n                    Male\n                 </option>\n                  <option value=\"Female\">\n                     Female\n                 </option>\n           </select>\n              <label>Roles</label>\n                 <select class=\"form-control form-control-sm\" name=\"role\" [(ngModel)]=\"user.Role\">\n                      <option selected=\"selected\" value=\" Merchant Agent\">\n                          Merchant Agent\n                       </option>\n                        <option value=\"Merchant Admin\">\n                            Merchant Admin\n                       </option>\n                 </select>\n                 <label>Default Password: &nbsp; <strong>password1</strong></label>\n          </form>\n         </div>\n        </div>\n\n      </div>\n      <div class=\"card-footer \">\n          <a href=\"javascript:;\" class=\"btn btn btn-sm mb-3\" (click)=\"Ok(user)\" style=\"background-color: orange\">Save User </a>\n\n          &nbsp; <a href=\"javascript:;\" class=\"btn btn btn-sm mb-3\" [routerLink]=\"['/agent']\" > Back to List </a>\n      </div>\n  </div>\n  </div>\n\n   </div>\n   </div>\n\n\n"

/***/ }),

/***/ "../src/app/account/account.component.ts":
/*!***********************************************!*\
  !*** ../src/app/account/account.component.ts ***!
  \***********************************************/
/*! exports provided: AccountComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AccountComponent", function() { return AccountComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../service/account.service */ "../src/app/service/account.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__);
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var AccountComponent = /** @class */ (function () {
    function AccountComponent(router, toastr, account, spinnerService, storage) {
        this.router = router;
        this.toastr = toastr;
        this.account = account;
        this.spinnerService = spinnerService;
        this.storage = storage;
        this.user = new _shared_model__WEBPACK_IMPORTED_MODULE_1__["AdminUser"]();
    }
    AccountComponent.prototype.ngOnInit = function () {
    };
    AccountComponent.prototype.Ok = function (model) {
        var self = this;
        if (model === null) {
            self.toastr.error('User model cannot be empty ');
        }
        console.log(model.Role);
        this.account.CreateUser(model).subscribe(function (c) {
            if (c.Succeeded) {
                self.toastr.success('Operation successful');
            }
            else {
                self.toastr.error('Operation failed ' + c.Message);
            }
        }, function (e) {
            self.toastr.error('Error in operation ' + e);
        });
    };
    AccountComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-account',
            template: __webpack_require__(/*! ./account.component.html */ "../src/app/account/account.component.html"),
            styles: [__webpack_require__(/*! ./account.component.css */ "../src/app/account/account.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"], ngx_toastr__WEBPACK_IMPORTED_MODULE_3__["ToastrService"],
            _service_account_service__WEBPACK_IMPORTED_MODULE_4__["AccountService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__["Ng4LoadingSpinnerService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_6__["StorageService"]])
    ], AccountComponent);
    return AccountComponent;
}());



/***/ }),

/***/ "../src/app/account/agent.component.html":
/*!***********************************************!*\
  !*** ../src/app/account/agent.component.html ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">Agent Report</h5>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" [routerLink]=\"['/account']\"><i class=\"fa fa-plus\"></i> Add Admin User </a>\n                      &nbsp;  <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" (click)=\"reloadPage()\">Refresh </a>\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control \" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchModel.Search\" type=\"text\">\n                          &nbsp; <span>StartDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"stardate\" name=\"stardate\" [(ngModel)]=\"searchModel.StartDate\" >\n                          &nbsp; <span>EndDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"enddate\" name=\"enddate\" [(ngModel)]=\"searchModel.EndDate\" >\n                          &nbsp;\n                          <a href=\"javascript:;\" class=\"btn btn btn-sm mb-2\" (click)=\"SearchCustomer(searchModel)\"  style=\"background-color: orange\"><i class=\"fa fa-search\"></i>Search </a>\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \" >\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>First Name </th>\n                              <th>Last Name</th>\n                              <th>Gender</th>\n                              <th>Address</th>\n                              <th>UserName</th>\n                              <th>Role</th>\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of response; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.FirstName}} </td>\n                              <td>{{item.LastName}} </td>\n                              <td>{{item.Gender}} </td>\n                              <td>{{item.Address}}</td>\n                              <td>{{item.UserName}}</td>\n                              <td>{{item.Role}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <!-- <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No User found</span>\n                    </div> -->\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/account/agent.component.ts":
/*!*********************************************!*\
  !*** ../src/app/account/agent.component.ts ***!
  \*********************************************/
/*! exports provided: AgentComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AgentComponent", function() { return AgentComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_6___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_6__);
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/account.service */ "../src/app/service/account.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var AgentComponent = /** @class */ (function () {
    function AgentComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.response = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.users = new Array();
        this.searchModel = new _shared_model__WEBPACK_IMPORTED_MODULE_2__["SearchModel"]();
    }
    AgentComponent.prototype.reloadPage = function () {
        document.location.reload();
    };
    AgentComponent.prototype.ngOnInit = function () {
        var self = this;
        this.LoadFirstPage();
        // this.service.GetAdminUser().subscribe(c => {
        //      self.users = c.Result;
        // });
    };
    AgentComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    AgentComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    AgentComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0;
        return result;
    };
    // GetAdminUserSearch
    AgentComponent.prototype.SearchCustomer = function (searchMod) {
        var self = this;
        self.service.GetAdminUserSearch(searchMod).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    AgentComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.GetAdminUserPaged(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    AgentComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-agent',
            template: __webpack_require__(/*! ./agent.component.html */ "../src/app/account/agent.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_5__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_6__["Ng4LoadingSpinnerService"], _service_account_service__WEBPACK_IMPORTED_MODULE_7__["AccountService"]])
    ], AgentComponent);
    return AgentComponent;
}());



/***/ }),

/***/ "../src/app/account/changepassword.component.html":
/*!********************************************************!*\
  !*** ../src/app/account/changepassword.component.html ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n <div class=\"content content-custom\">\n  <div class=\"card \">\n    <div class=\"card-header \">\n        <h4 class=\"card-title\">Change Password </h4>\n    </div>\n    <div class=\"card-body \">\n      <div class=\"row\">\n       <div class=\"col-md-4\">\n        <form method=\"#\" action=\"#\">\n            <label>Password</label>\n            <div class=\"form-group\">\n                <input type=\"password\" name=\"password\" [(ngModel)]=\"changePassword.Password\"  class=\"form-control\">\n            </div>\n            <label>New Password</label>\n            <div class=\"form-group\">\n                <input type=\"password\" name=\"newpassword\"  [(ngModel)]=\"changePassword.NewPassword\" class=\"form-control\">\n            </div>\n            <label>Confirm Password</label>\n            <div class=\"form-group\">\n                <input type=\"password\" name=\"confirmpassword\" [(ngModel)]=\"changePassword.ConfirmPassword\" class=\"form-control\">\n            </div>\n        </form>\n       </div>\n      </div>\n\n    </div>\n    <div class=\"card-footer \">\n        <a href=\"javascript:;\" class=\"btn btn btn-sm mb-3\" (click)=\"Ok(changePassword)\" style=\"background-color: orange\">Update Password </a>\n    </div>\n</div>\n</div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/account/changepassword.component.ts":
/*!******************************************************!*\
  !*** ../src/app/account/changepassword.component.ts ***!
  \******************************************************/
/*! exports provided: ChangePasswordComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ChangePasswordComponent", function() { return ChangePasswordComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__);
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/account.service */ "../src/app/service/account.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ChangePasswordComponent = /** @class */ (function () {
    function ChangePasswordComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.changePassword = new _shared_model__WEBPACK_IMPORTED_MODULE_1__["PasswordChange"]();
    }
    ChangePasswordComponent.prototype.ngOnInit = function () {
        // this.toastr.success('Hello world!', 'Toastr fun!');
    };
    ChangePasswordComponent.prototype.Ok = function (model) {
        var self = this;
        if (model === null || model === undefined) {
            this.toastr.error('Password data cannot be empty');
        }
        if (model.NewPassword !== model.ConfirmPassword) {
            this.toastr.error('New Password must be the same with confirm password');
        }
        if (model.Password !== '') {
            this.toastr.error('Password cannot be empty');
        }
        model.UserId = 0;
        this.spinnerService.show();
        self.service.ChangePasswordOk(model).subscribe(function (c) {
            if (c.Succeeded) {
                self.toastr.success('Operation successful');
                self.changePassword = new _shared_model__WEBPACK_IMPORTED_MODULE_1__["PasswordChange"]();
            }
            else {
                self.toastr.error('Operation failed ' + c.Message);
            }
            self.changePassword = new _shared_model__WEBPACK_IMPORTED_MODULE_1__["PasswordChange"]();
            self.spinnerService.hide();
        }, function (e) {
            console.log(e);
            self.toastr.error('Operation failed ' + e);
            self.spinnerService.hide();
        });
    };
    ChangePasswordComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-changepassword',
            template: __webpack_require__(/*! ./changepassword.component.html */ "../src/app/account/changepassword.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_2__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_4__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__["Ng4LoadingSpinnerService"], _service_account_service__WEBPACK_IMPORTED_MODULE_6__["AccountService"]])
    ], ChangePasswordComponent);
    return ChangePasswordComponent;
}());



/***/ }),

/***/ "../src/app/account/forgotpass.component.html":
/*!****************************************************!*\
  !*** ../src/app/account/forgotpass.component.html ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n    <app-navigation></app-navigation>\n    <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n    <app-topnav></app-topnav>\n    <div class=\"panel-header panel-header-sm panel-header-custom\">\n   </div>\n       <div class=\"content content-custom\">\n        <div class=\"card\">\n            <div class=\"card-header\">\n                <h5 class=\"title\">User Report</h5>\n                <hr>\n                <div class=\"row\">\n                    <div class=\"col-sm-6\">\n     <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" (click)=\"reloadPage()\">Refresh </a>\n                       <!-- <a href=\"javascript:;\" class=\"btn btn-default btn-sm\"><i class=\"fa fa-plus\"></i> Add Withdrawal </a> -->\n                        <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                        <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                    </div>\n                    <div class=\"col-sm-6\">\n                        <form class=\"form-inline justify-content-sm-end\">\n                            <input class=\"form-control \" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchModel.Search\" type=\"text\">\n                            &nbsp; <span>StartDate</span>\n                            <input type=\"date\" class=\"form-control\" placeholder=\"stardate\" name=\"stardate\" [(ngModel)]=\"searchModel.StartDate\" >\n                            &nbsp; <span>EndDate</span>\n                            <input type=\"date\" class=\"form-control\" placeholder=\"enddate\" name=\"enddate\" [(ngModel)]=\"searchModel.EndDate\" >\n                            &nbsp;\n                            <a href=\"javascript:;\" class=\"btn btn btn-sm mb-2\" (click)=\"SearcUsersData(searchModel)\"  style=\"background-color: orange\"><i class=\"fa fa-search\"></i>Search </a>\n                        </form>\n                    </div>\n                </div>\n            </div>\n            <div class=\"card-body\">\n                <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                    <table class=\"table table-bordered\">\n                        <thead>\n                            <tr class=\"h6\">\n                                <th>SN</th>\n                                <th>First Name </th>\n                                <th>Last Name</th>\n                                <th>Gender</th>\n                                <th>Address</th>\n                                <th>UserName</th>\n                                <th>Entry Date </th>\n                            </tr>\n                        </thead>\n                        <tbody>\n                            <tr *ngFor=\"let item of response; let i=index \">\n                                <td>{{i+1}}</td>\n                                <td>{{item.FirstName}} </td>\n                                <td>{{item.LastName}} </td>\n                                <td>{{item.Gender}} </td>\n                                <td>{{item.Address}}</td>\n                                <td>{{item.UserName}}</td>\n                                <td>{{item.CreatedDate | date }}</td>\n                            </tr>\n\n                        </tbody>\n                    </table>\n                    <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                        <span class=\"text-muted\" style=\"font-size:22px;\">No User found</span>\n                      </div>\n\n                      <div class=\"row\">\n                        <div class=\"col-lg-12\" style=\"text-align:right\">\n                          <ul class=\"pagination\">\n                            <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                            <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                              <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                                {{p + 1}}\n                              </a>\n                            </li>\n                            <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                          </ul>\n                        </div>\n                      </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n   </div>\n   </div>\n\n\n"

/***/ }),

/***/ "../src/app/account/forgotpass.component.ts":
/*!**************************************************!*\
  !*** ../src/app/account/forgotpass.component.ts ***!
  \**************************************************/
/*! exports provided: ForgotPassComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ForgotPassComponent", function() { return ForgotPassComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__);
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/account.service */ "../src/app/service/account.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var ForgotPassComponent = /** @class */ (function () {
    function ForgotPassComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.response = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.searchModel = new _shared_model__WEBPACK_IMPORTED_MODULE_2__["SearchModel"]();
    }
    ForgotPassComponent.prototype.reloadPage = function () {
        document.location.reload();
    };
    ForgotPassComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    ForgotPassComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    ForgotPassComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get(Math.ceil(this.data.SequenceLength / this.pageSize) - 1);
        }
    };
    ForgotPassComponent.prototype.HasNoPage = function () {
        var result = this.data == null ||
            typeof this.data === "undefined" ||
            this.data.Page.length === 0;
        return result;
    };
    ForgotPassComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getUserList(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    ForgotPassComponent.prototype.SearcUsersData = function (searchMod) {
        var self = this;
        self.service.getUserAdminList(searchMod).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    ForgotPassComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-forgotpass",
            template: __webpack_require__(/*! ./forgotpass.component.html */ "../src/app/account/forgotpass.component.html")
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_6__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__["Ng4LoadingSpinnerService"],
            _service_account_service__WEBPACK_IMPORTED_MODULE_7__["AccountService"]])
    ], ForgotPassComponent);
    return ForgotPassComponent;
}());



/***/ }),

/***/ "../src/app/account/login.component.css":
/*!**********************************************!*\
  !*** ../src/app/account/login.component.css ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "../src/app/account/login.component.html":
/*!***********************************************!*\
  !*** ../src/app/account/login.component.html ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"index-bg\">\n  <div class=\"bg-overlay\">\n    <div class=\"container container-index\">\n      <div class=\"row\">\n        <div class=\"col-md-4\">\n        </div>\n        <div class=\"col-md-4\">\n          <div class=\"card\">\n            <div class=\"card-header card-body-custom\">\n              <div class=\"logo-index\">\n                <img src=\"../assets/img/eureka-logo.jpg\" class=\"img-responsive\" alt=\"Image\">\n              </div>\n            </div>\n            <div class=\"card-body login-card-custom\">\n              <form class=\"form\" method=\"\" action=\"\">\n                <div class=\"input-group\">\n                  <span class=\"input-group-addon\">\n                    <i class=\"now-ui-icons users_circle-08\"></i>\n                  </span>\n                  <input type=\"text\" class=\"form-control\" name=\"UserName\" [(ngModel)]=\"login.UserName\" placeholder=\"UserName\"\n                    required />\n                </div>\n                <div class=\"input-group\">\n                  <span class=\"input-group-addon\">\n                    <i class=\"now-ui-icons text_caps-small\"></i>\n                  </span>\n                  <input type=\"password\" placeholder=\"Password\" name=\"Password\" [(ngModel)]=\"login.Password\" class=\"form-control\"\n                    required />\n                </div>\n              </form>\n            </div>\n            <div class=\"card-footer text-center\">\n              <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" (click)=\"onlogin(login)\" style=\"background-color: orange\">\n                Login </a>\n            </div>\n            <div class=\"card-footer\" style=\"float: left;width: 100%\">\n              <div style=\"float: left;\">\n                <a href=\"javascript:;\" class=\"link footer-link\" style=\"color:blue;text-decoration: none\"> <b><i class=\"fa fa-user-plus\"></i>\n                    Sign up</b></a>\n              </div>\n              <div style=\"float: right;\">\n                <a href=\"javascript:;\" class=\"link footer-link\" style=\"color:blue;text-decoration: none\"><i class=\"fa fa-unlock-alt\"></i>\n                  Forgot password\n                </a>\n              </div>\n            </div>\n          </div>\n        </div>\n      </div>\n    </div>\n    <!-- Footer -->\n  </div>\n</div>\n"

/***/ }),

/***/ "../src/app/account/login.component.ts":
/*!*********************************************!*\
  !*** ../src/app/account/login.component.ts ***!
  \*********************************************/
/*! exports provided: LoginComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoginComponent", function() { return LoginComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4__);
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var _shared_Constants__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/Constants */ "../src/app/shared/Constants.ts");
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/account.service */ "../src/app/service/account.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var LoginComponent = /** @class */ (function () {
    function LoginComponent(router, toastr, account, spinnerService, storage) {
        this.router = router;
        this.toastr = toastr;
        this.account = account;
        this.spinnerService = spinnerService;
        this.storage = storage;
        this.login = new _shared_model__WEBPACK_IMPORTED_MODULE_1__["UserLogin"]();
    }
    LoginComponent.prototype.ngOnInit = function () { };
    LoginComponent.prototype.onlogin = function (login) {
        var _this = this;
        this.spinnerService.show();
        // this.loaderService.display(true);
        var self = this;
        this.account.getUserToken(login).subscribe(function (resp) {
            if (resp.Succeeded) {
                var token = new _shared_model__WEBPACK_IMPORTED_MODULE_1__["Token"]();
                token.token = resp.Result.token;
                token.expiration = resp.Result.expiration;
                token.user = resp.Result.user;
                //// log into local storage
                // self.storage.token = token;
                // self.storage.user = token.user;
                localStorage.setItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_6__["Constants"].OAuthTokenKey, JSON.stringify(token.token));
                localStorage.setItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_6__["Constants"].UserKey, JSON.stringify(token.user));
                // this.toastr.success('successfully sign in', 'success!');
                // self.loaderService.display(false);
                console.log(token.user.Role);
                _this.router.navigate(["/dashboard"]);
                self.spinnerService.hide();
            }
            else {
                self.toastr.error(resp.Message, "Error!");
                // this.loaderService.display(false);
                self.spinnerService.hide();
                _this.router.navigate(["/login"]);
            }
        }, function (error) {
            console.log("login error");
            _this.toastr.error("Failed to login " + error, "Error!");
            _this.spinnerService.hide();
            _this.router.navigate(["/login"]);
        });
    };
    LoginComponent.prototype.KeyPress = function ($event) {
        // If Enter was Pressed
        if ($event.keyCode === 13) {
            // this.SignUp();
        }
    };
    LoginComponent.prototype.Redirect = function (role) {
        if (role === _shared_Constants__WEBPACK_IMPORTED_MODULE_6__["Constants"].Roles.Administrator) {
            this.toastr.info(role);
            this.router.navigate([" "]);
        }
        else if (role === _shared_Constants__WEBPACK_IMPORTED_MODULE_6__["Constants"].Roles.User) {
            this.router.navigate(["/login"]);
        }
    };
    LoginComponent.prototype.redirectTo = function () {
        this.router.navigate(["/forgotpass"]);
    };
    LoginComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-login",
            template: __webpack_require__(/*! ./login.component.html */ "../src/app/account/login.component.html"),
            styles: [__webpack_require__(/*! ./login.component.css */ "../src/app/account/login.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_3__["ToastrService"],
            _service_account_service__WEBPACK_IMPORTED_MODULE_7__["AccountService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4__["Ng4LoadingSpinnerService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_5__["StorageService"]])
    ], LoginComponent);
    return LoginComponent;
}());



/***/ }),

/***/ "../src/app/account/profile.component.html":
/*!*************************************************!*\
  !*** ../src/app/account/profile.component.html ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n    <app-navigation></app-navigation>\n    <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n    <app-topnav></app-topnav>\n    <div class=\"panel-header panel-header-sm panel-header-custom\">\n   </div>\n   <div class=\"content content-custom\">\n    <div class=\"card \">\n      <div class=\"card-header \">\n          <h4 class=\"card-title\">User profile </h4>\n      </div>\n      <div class=\"card-body \">\n        <div class=\"row\">\n         <div class=\"col-md-6\">\n          <form method=\"#\" action=\"#\">\n              <label>First Name</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"FirstName\" [(ngModel)]=\"user.FirstName\"  class=\"form-control\">\n              </div>\n              <label>Last Name</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"LastName\"  [(ngModel)]=\"user.LastName\" class=\"form-control\">\n              </div>\n              <label>Email</label>\n              <div class=\"form-group\">\n                  <input type=\"email\" name=\"EmailAddress\" [(ngModel)]=\"user.EmailAddress\" class=\"form-control\">\n              </div>\n              <label>Address</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"Address\" [(ngModel)]=\"user.Address\" class=\"form-control\">\n              </div>\n              <label>Mobile</label>\n              <div class=\"form-group\">\n                  <input type=\"text\" name=\"Mobile\" [(ngModel)]=\"user.Mobile\" class=\"form-control\">\n              </div>\n          </form>\n         </div>\n        </div>\n\n      </div>\n      <div class=\"card-footer \">\n          <a href=\"javascript:;\" class=\"btn btn btn-sm mb-3\" (click)=\"Ok(user)\" style=\"background-color: orange\">Update Profile </a>\n      </div>\n  </div>\n  </div>\n\n   </div>\n   </div>\n\n\n"

/***/ }),

/***/ "../src/app/account/profile.component.ts":
/*!***********************************************!*\
  !*** ../src/app/account/profile.component.ts ***!
  \***********************************************/
/*! exports provided: ProfileComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProfileComponent", function() { return ProfileComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4__);
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../service/account.service */ "../src/app/service/account.service.ts");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ProfileComponent = /** @class */ (function () {
    function ProfileComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.user = new _shared_model__WEBPACK_IMPORTED_MODULE_1__["User"]();
    }
    ProfileComponent.prototype.ngOnInit = function () {
        var self = this;
        self.service.getCurrentUser().subscribe(function (c) {
            self.user.Address = c.Result.Address;
            self.user.EmailAddress = c.Result.EmailAddress;
            self.user.Mobile = c.Result.Mobile;
            self.user.FirstName = c.Result.FirstName;
            self.user.LastName = c.Result.LastName;
        });
    };
    ProfileComponent.prototype.Ok = function (model) {
        var self = this;
        this.service.updateWebProfile(model).subscribe(function (c) {
            if (c.Succeeded) {
                self.toastr.success('Operation successful');
            }
            else {
                self.toastr.error('Operation failed');
            }
        });
    };
    ProfileComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-profile',
            template: __webpack_require__(/*! ./profile.component.html */ "../src/app/account/profile.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_3__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_6__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_4__["Ng4LoadingSpinnerService"], _service_account_service__WEBPACK_IMPORTED_MODULE_5__["AccountService"]])
    ], ProfileComponent);
    return ProfileComponent;
}());



/***/ }),

/***/ "../src/app/account/users.component.html":
/*!***********************************************!*\
  !*** ../src/app/account/users.component.html ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n    <app-navigation></app-navigation>\n    <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n    <app-topnav></app-topnav>\n    <div class=\"panel-header panel-header-sm panel-header-custom\">\n   </div>\n       <div class=\"content content-custom\">\n        <div class=\"card\">\n            <div class=\"card-header\">\n                <h5 class=\"title\">User Report</h5>\n                <hr>\n                <div class=\"row\">\n                    <div class=\"col-sm-6\">\n     <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" (click)=\"reloadPage()\">Refresh </a>\n                       <!-- <a href=\"javascript:;\" class=\"btn btn-default btn-sm\"><i class=\"fa fa-plus\"></i> Add Withdrawal </a> -->\n                        <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                        <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                    </div>\n                    <div class=\"col-sm-6\">\n                        <form class=\"form-inline justify-content-sm-end\">\n                            <input class=\"form-control \" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchModel.Search\" type=\"text\">\n                            &nbsp; <span>StartDate</span>\n                            <input type=\"date\" class=\"form-control\" placeholder=\"stardate\" name=\"stardate\" [(ngModel)]=\"searchModel.StartDate\" >\n                            &nbsp; <span>EndDate</span>\n                            <input type=\"date\" class=\"form-control\" placeholder=\"enddate\" name=\"enddate\" [(ngModel)]=\"searchModel.EndDate\" >\n                            &nbsp;\n                            <a href=\"javascript:;\" class=\"btn btn btn-sm mb-2\" (click)=\"SearcUsersData(searchModel)\"  style=\"background-color: orange\"><i class=\"fa fa-search\"></i>Search </a>\n                        </form>\n                    </div>\n                </div>\n            </div>\n            <div class=\"card-body\">\n                <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                    <table class=\"table table-bordered\">\n                        <thead>\n                            <tr class=\"h6\">\n                                <th>SN</th>\n                                <th>First Name </th>\n                                <th>Last Name</th>\n                                <th>Gender</th>\n                                <th>Address</th>\n                                <th>UserName</th>\n                                <th>Entry Date </th>\n                            </tr>\n                        </thead>\n                        <tbody>\n                            <tr *ngFor=\"let item of response; let i=index \">\n                                <td>{{i+1}}</td>\n                                <td>{{item.FirstName}} </td>\n                                <td>{{item.LastName}} </td>\n                                <td>{{item.Gender}} </td>\n                                <td>{{item.Address}}</td>\n                                <td>{{item.UserName}}</td>\n                                <td>{{item.CreatedDate | date }}</td>\n                            </tr>\n\n                        </tbody>\n                    </table>\n                    <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                        <span class=\"text-muted\" style=\"font-size:22px;\">No User found</span>\n                      </div>\n\n                      <div class=\"row\">\n                        <div class=\"col-lg-12\" style=\"text-align:right\">\n                          <ul class=\"pagination\">\n                            <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                            <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                              <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                                {{p + 1}}\n                              </a>\n                            </li>\n                            <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                          </ul>\n                        </div>\n                      </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n   </div>\n   </div>\n\n\n"

/***/ }),

/***/ "../src/app/account/users.component.ts":
/*!*********************************************!*\
  !*** ../src/app/account/users.component.ts ***!
  \*********************************************/
/*! exports provided: UsersComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UsersComponent", function() { return UsersComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__);
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/account.service */ "../src/app/service/account.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var UsersComponent = /** @class */ (function () {
    function UsersComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.response = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.searchModel = new _shared_model__WEBPACK_IMPORTED_MODULE_2__["SearchModel"]();
    }
    UsersComponent.prototype.reloadPage = function () {
        document.location.reload();
    };
    UsersComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    UsersComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    UsersComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    UsersComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0;
        return result;
    };
    UsersComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getUserList(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    UsersComponent.prototype.SearcUsersData = function (searchMod) {
        var self = this;
        self.service.getUserAdminList(searchMod).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_1__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    UsersComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-users',
            template: __webpack_require__(/*! ./users.component.html */ "../src/app/account/users.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_6__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_5__["Ng4LoadingSpinnerService"], _service_account_service__WEBPACK_IMPORTED_MODULE_7__["AccountService"]])
    ], UsersComponent);
    return UsersComponent;
}());



/***/ }),

/***/ "../src/app/app.component.css":
/*!************************************!*\
  !*** ../src/app/app.component.css ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "../src/app/app.component.html":
/*!*************************************!*\
  !*** ../src/app/app.component.html ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<router-outlet>\n  <ng4-loading-spinner> </ng4-loading-spinner>\n</router-outlet>\n\n"

/***/ }),

/***/ "../src/app/app.component.ts":
/*!***********************************!*\
  !*** ../src/app/app.component.ts ***!
  \***********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'payajouxapp';
    }
    AppComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "../src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "../src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "../src/app/app.module.ts":
/*!********************************!*\
  !*** ../src/app/app.module.ts ***!
  \********************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "../node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common */ "../node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ "../node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./app.component */ "../src/app/app.component.ts");
/* harmony import */ var _account_account_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./account/account.component */ "../src/app/account/account.component.ts");
/* harmony import */ var _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./dashboard/dashboard.component */ "../src/app/dashboard/dashboard.component.ts");
/* harmony import */ var _account_login_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./account/login.component */ "../src/app/account/login.component.ts");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/platform-browser/animations */ "../node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_12___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_12__);
/* harmony import */ var _shared_navigation_navigation_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./shared/navigation/navigation.component */ "../src/app/shared/navigation/navigation.component.ts");
/* harmony import */ var _shared_navigation_topnav_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./shared/navigation/topnav.component */ "../src/app/shared/navigation/topnav.component.ts");
/* harmony import */ var _customer_customer_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./customer/customer.component */ "../src/app/customer/customer.component.ts");
/* harmony import */ var _service_data_service__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./service/data.service */ "../src/app/service/data.service.ts");
/* harmony import */ var _service_account_service__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./service/account.service */ "../src/app/service/account.service.ts");
/* harmony import */ var _service_customer_service__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./service/customer.service */ "../src/app/service/customer.service.ts");
/* harmony import */ var _service_report_service__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./service/report.service */ "../src/app/service/report.service.ts");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var _customer_activecustomer_component__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./customer/activecustomer.component */ "../src/app/customer/activecustomer.component.ts");
/* harmony import */ var _customer_inactivecustomer_component__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./customer/inactivecustomer.component */ "../src/app/customer/inactivecustomer.component.ts");
/* harmony import */ var _service_transaction_service__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./service/transaction.service */ "../src/app/service/transaction.service.ts");
/* harmony import */ var _transaction_transaction_component__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./transaction/transaction.component */ "../src/app/transaction/transaction.component.ts");
/* harmony import */ var _transaction_credittransaction_component__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./transaction/credittransaction.component */ "../src/app/transaction/credittransaction.component.ts");
/* harmony import */ var _transaction_debittransaction_component__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./transaction/debittransaction.component */ "../src/app/transaction/debittransaction.component.ts");
/* harmony import */ var _withdrawal_withdrawal_component__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./withdrawal/withdrawal.component */ "../src/app/withdrawal/withdrawal.component.ts");
/* harmony import */ var _withdrawal_paidwithdrawal_component__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! ./withdrawal/paidwithdrawal.component */ "../src/app/withdrawal/paidwithdrawal.component.ts");
/* harmony import */ var _withdrawal_approvedwithdrawal_component__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! ./withdrawal/approvedwithdrawal.component */ "../src/app/withdrawal/approvedwithdrawal.component.ts");
/* harmony import */ var _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_30__ = __webpack_require__(/*! ./service/withdrawal.service */ "../src/app/service/withdrawal.service.ts");
/* harmony import */ var _account_users_component__WEBPACK_IMPORTED_MODULE_31__ = __webpack_require__(/*! ./account/users.component */ "../src/app/account/users.component.ts");
/* harmony import */ var _account_profile_component__WEBPACK_IMPORTED_MODULE_32__ = __webpack_require__(/*! ./account/profile.component */ "../src/app/account/profile.component.ts");
/* harmony import */ var _account_agent_component__WEBPACK_IMPORTED_MODULE_33__ = __webpack_require__(/*! ./account/agent.component */ "../src/app/account/agent.component.ts");
/* harmony import */ var _account_changepassword_component__WEBPACK_IMPORTED_MODULE_34__ = __webpack_require__(/*! ./account/changepassword.component */ "../src/app/account/changepassword.component.ts");
/* harmony import */ var _customer_createcustomer_component__WEBPACK_IMPORTED_MODULE_35__ = __webpack_require__(/*! ./customer/createcustomer.component */ "../src/app/customer/createcustomer.component.ts");
/* harmony import */ var _transaction_createtransaction_component__WEBPACK_IMPORTED_MODULE_36__ = __webpack_require__(/*! ./transaction/createtransaction.component */ "../src/app/transaction/createtransaction.component.ts");
/* harmony import */ var _transaction_transactionlog_component__WEBPACK_IMPORTED_MODULE_37__ = __webpack_require__(/*! ./transaction/transactionlog.component */ "../src/app/transaction/transactionlog.component.ts");
/* harmony import */ var _withdrawal_createwithdrawal_component__WEBPACK_IMPORTED_MODULE_38__ = __webpack_require__(/*! ./withdrawal/createwithdrawal.component */ "../src/app/withdrawal/createwithdrawal.component.ts");
/* harmony import */ var _withdrawal_withdrawalagent_component__WEBPACK_IMPORTED_MODULE_39__ = __webpack_require__(/*! ./withdrawal/withdrawalagent.component */ "../src/app/withdrawal/withdrawalagent.component.ts");
/* harmony import */ var _customer_viewcustomer_component__WEBPACK_IMPORTED_MODULE_40__ = __webpack_require__(/*! ./customer/viewcustomer.component */ "../src/app/customer/viewcustomer.component.ts");
/* harmony import */ var _customer_updatecustomer_component__WEBPACK_IMPORTED_MODULE_41__ = __webpack_require__(/*! ./customer/updatecustomer.component */ "../src/app/customer/updatecustomer.component.ts");
/* harmony import */ var _feecharges_smsdebit_component__WEBPACK_IMPORTED_MODULE_42__ = __webpack_require__(/*! ./feecharges/smsdebit.component */ "../src/app/feecharges/smsdebit.component.ts");
/* harmony import */ var _account_forgotpass_component__WEBPACK_IMPORTED_MODULE_43__ = __webpack_require__(/*! ./account/forgotpass.component */ "../src/app/account/forgotpass.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












































// import {NgAutoCompleteModule} from 'ng-auto-complete';
var routes = [
    { path: "", redirectTo: "/dashboard", pathMatch: "full" },
    { path: "dashboard", component: _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_7__["DashboardComponent"] },
    { path: "login", component: _account_login_component__WEBPACK_IMPORTED_MODULE_8__["LoginComponent"] },
    { path: "customer", component: _customer_customer_component__WEBPACK_IMPORTED_MODULE_15__["CustomerComponent"] },
    { path: "active-customer", component: _customer_activecustomer_component__WEBPACK_IMPORTED_MODULE_21__["ActiveCustomerComponent"] },
    { path: "inactive-customer", component: _customer_inactivecustomer_component__WEBPACK_IMPORTED_MODULE_22__["InActiveCustomerComponent"] },
    { path: "transaction", component: _transaction_transaction_component__WEBPACK_IMPORTED_MODULE_24__["TransactionComponent"] },
    { path: "credittransaction", component: _transaction_credittransaction_component__WEBPACK_IMPORTED_MODULE_25__["CreditTransactionComponent"] },
    { path: "debittransaction", component: _transaction_debittransaction_component__WEBPACK_IMPORTED_MODULE_26__["DebitTransactionComponent"] },
    { path: "withdrawal", component: _withdrawal_withdrawal_component__WEBPACK_IMPORTED_MODULE_27__["WithdrawalComponent"] },
    { path: "paidwithdrawal", component: _withdrawal_paidwithdrawal_component__WEBPACK_IMPORTED_MODULE_28__["PaidWithdrawalComponent"] },
    { path: "approvedwithdrawal", component: _withdrawal_approvedwithdrawal_component__WEBPACK_IMPORTED_MODULE_29__["ApprovedWithdrawalComponent"] },
    { path: "users", component: _account_users_component__WEBPACK_IMPORTED_MODULE_31__["UsersComponent"] },
    { path: "profile", component: _account_profile_component__WEBPACK_IMPORTED_MODULE_32__["ProfileComponent"] },
    { path: "agent", component: _account_agent_component__WEBPACK_IMPORTED_MODULE_33__["AgentComponent"] },
    { path: "change-password", component: _account_changepassword_component__WEBPACK_IMPORTED_MODULE_34__["ChangePasswordComponent"] },
    { path: "createcustomer", component: _customer_createcustomer_component__WEBPACK_IMPORTED_MODULE_35__["CreateCustomerComponent"] },
    { path: "createtransaction", component: _transaction_createtransaction_component__WEBPACK_IMPORTED_MODULE_36__["CreateTransactionComponent"] },
    { path: "transactionlog", component: _transaction_transactionlog_component__WEBPACK_IMPORTED_MODULE_37__["TransactionLogComponent"] },
    { path: "createwithdrawal", component: _withdrawal_createwithdrawal_component__WEBPACK_IMPORTED_MODULE_38__["CreateWithdrawalComponent"] },
    { path: "account", component: _account_account_component__WEBPACK_IMPORTED_MODULE_6__["AccountComponent"] },
    { path: "withdrawalagent/:id", component: _withdrawal_withdrawalagent_component__WEBPACK_IMPORTED_MODULE_39__["WithdrawalAgentComponent"] },
    { path: "customer-view/:id", component: _customer_viewcustomer_component__WEBPACK_IMPORTED_MODULE_40__["ViewCustomerComponent"] },
    { path: "customer-update/:id", component: _customer_updatecustomer_component__WEBPACK_IMPORTED_MODULE_41__["UpdateCustomerComponent"] },
    { path: "smsdebit", component: _feecharges_smsdebit_component__WEBPACK_IMPORTED_MODULE_42__["SmsDebitComponent"] },
    { path: "techdebit", component: _feecharges_smsdebit_component__WEBPACK_IMPORTED_MODULE_42__["SmsDebitComponent"] },
    { path: "smspayment", component: _feecharges_smsdebit_component__WEBPACK_IMPORTED_MODULE_42__["SmsDebitComponent"] },
    { path: "techpayment", component: _feecharges_smsdebit_component__WEBPACK_IMPORTED_MODULE_42__["SmsDebitComponent"] },
    { path: "forgotpass", component: _account_forgotpass_component__WEBPACK_IMPORTED_MODULE_43__["ForgotPassComponent"] },
    { path: "**", component: _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_7__["DashboardComponent"] }
];
//
// customer-update
//
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"],
                _account_account_component__WEBPACK_IMPORTED_MODULE_6__["AccountComponent"],
                _account_login_component__WEBPACK_IMPORTED_MODULE_8__["LoginComponent"],
                _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_7__["DashboardComponent"],
                _shared_navigation_navigation_component__WEBPACK_IMPORTED_MODULE_13__["NavigationComponent"],
                _shared_navigation_topnav_component__WEBPACK_IMPORTED_MODULE_14__["TopNavComponent"],
                _customer_customer_component__WEBPACK_IMPORTED_MODULE_15__["CustomerComponent"],
                _customer_activecustomer_component__WEBPACK_IMPORTED_MODULE_21__["ActiveCustomerComponent"],
                _customer_inactivecustomer_component__WEBPACK_IMPORTED_MODULE_22__["InActiveCustomerComponent"],
                _transaction_transaction_component__WEBPACK_IMPORTED_MODULE_24__["TransactionComponent"],
                _transaction_credittransaction_component__WEBPACK_IMPORTED_MODULE_25__["CreditTransactionComponent"],
                _transaction_debittransaction_component__WEBPACK_IMPORTED_MODULE_26__["DebitTransactionComponent"],
                _withdrawal_withdrawal_component__WEBPACK_IMPORTED_MODULE_27__["WithdrawalComponent"],
                _withdrawal_paidwithdrawal_component__WEBPACK_IMPORTED_MODULE_28__["PaidWithdrawalComponent"],
                _withdrawal_approvedwithdrawal_component__WEBPACK_IMPORTED_MODULE_29__["ApprovedWithdrawalComponent"],
                _account_users_component__WEBPACK_IMPORTED_MODULE_31__["UsersComponent"],
                _account_agent_component__WEBPACK_IMPORTED_MODULE_33__["AgentComponent"],
                _account_profile_component__WEBPACK_IMPORTED_MODULE_32__["ProfileComponent"],
                _account_changepassword_component__WEBPACK_IMPORTED_MODULE_34__["ChangePasswordComponent"],
                _customer_createcustomer_component__WEBPACK_IMPORTED_MODULE_35__["CreateCustomerComponent"],
                _transaction_createtransaction_component__WEBPACK_IMPORTED_MODULE_36__["CreateTransactionComponent"],
                _transaction_transactionlog_component__WEBPACK_IMPORTED_MODULE_37__["TransactionLogComponent"],
                _withdrawal_createwithdrawal_component__WEBPACK_IMPORTED_MODULE_38__["CreateWithdrawalComponent"],
                _withdrawal_withdrawalagent_component__WEBPACK_IMPORTED_MODULE_39__["WithdrawalAgentComponent"],
                _customer_viewcustomer_component__WEBPACK_IMPORTED_MODULE_40__["ViewCustomerComponent"],
                _customer_updatecustomer_component__WEBPACK_IMPORTED_MODULE_41__["UpdateCustomerComponent"],
                _feecharges_smsdebit_component__WEBPACK_IMPORTED_MODULE_42__["SmsDebitComponent"],
                _account_forgotpass_component__WEBPACK_IMPORTED_MODULE_43__["ForgotPassComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
                _angular_common__WEBPACK_IMPORTED_MODULE_3__["CommonModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["BrowserAnimationsModule"],
                ngx_toastr__WEBPACK_IMPORTED_MODULE_10__["ToastrModule"].forRoot({
                    timeOut: 10000,
                    positionClass: "toast-top-right",
                    preventDuplicates: true
                }),
                ngx_toastr__WEBPACK_IMPORTED_MODULE_10__["ToastContainerModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_4__["FormsModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes, {
                    useHash: true,
                    enableTracing: false // for debburgin route ..
                    // onSameUrlNavigation: 'reload'
                }),
                ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_12__["Ng4LoadingSpinnerModule"].forRoot()
                // NgAutoCompleteModule
            ],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]],
            providers: [
                _service_data_service__WEBPACK_IMPORTED_MODULE_16__["DataService"],
                _service_account_service__WEBPACK_IMPORTED_MODULE_17__["AccountService"],
                _service_customer_service__WEBPACK_IMPORTED_MODULE_18__["CustomerService"],
                _service_report_service__WEBPACK_IMPORTED_MODULE_19__["ReportService"],
                _service_storage_service__WEBPACK_IMPORTED_MODULE_20__["StorageService"],
                _service_transaction_service__WEBPACK_IMPORTED_MODULE_23__["TransactionService"],
                _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_30__["WithdrawalService"]
            ],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"]]
            // schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "../src/app/customer/activecustomer.component.html":
/*!*********************************************************!*\
  !*** ../src/app/customer/activecustomer.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">Active Customer List</h5>\n              <p>The list shows all the   <code>active</code> customers\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" (click)=\"reloadPage()\">Refresh </a>\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control \" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchModel.Search\" type=\"text\">\n                          &nbsp; <span>StartDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"stardate\" name=\"stardate\" [(ngModel)]=\"searchModel.StartDate\" >\n                          &nbsp; <span>EndDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"enddate\" name=\"enddate\" [(ngModel)]=\"searchModel.EndDate\" >\n                          &nbsp;\n                          <a href=\"javascript:;\" class=\"btn btn btn-sm mb-2\"  style=\"background-color: orange\"><i class=\"fa fa-search\"></i>Search </a>\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>First Name</th>\n                              <th>Last Name</th>\n                              <th>Customer Code</th>\n                              <th>Phone Number</th>\n                              <th>User Name </th>\n                              <th>Customer Balance </th>\n\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of customers ; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.FirstName}}</td>\n                              <td>{{item.LastName}}</td>\n                              <td>{{item.CustomerCode}} </td>\n                              <td>{{item.Mobile}}</td>\n                              <td>{{item.UserName}}</td>\n                              <td>₦{{item.CustomerBalance | number}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No Customer found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/customer/activecustomer.component.ts":
/*!*******************************************************!*\
  !*** ../src/app/customer/activecustomer.component.ts ***!
  \*******************************************************/
/*! exports provided: ActiveCustomerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ActiveCustomerComponent", function() { return ActiveCustomerComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_customer_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/customer.service */ "../src/app/service/customer.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var ActiveCustomerComponent = /** @class */ (function () {
    function ActiveCustomerComponent(router, toastr, storage, spinnerService, customer) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.customer = customer;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.dashboard = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["DashboardModel"]();
        this.customers = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.searchModel = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["SearchModel"]();
    }
    ActiveCustomerComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    ActiveCustomerComponent.prototype.reloadPage = function () {
        document.location.reload();
    };
    ActiveCustomerComponent.prototype.GetStatus = function (status) {
    };
    ActiveCustomerComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    ActiveCustomerComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    ActiveCustomerComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0 || this.customers.length === 0 || this.customers.length === 0;
        return result;
    };
    ActiveCustomerComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.customer.getActiveCustomers(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.customers = self.data.Page;
            }
            return self.customers;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.customers;
        });
        return self.customers;
    };
    ActiveCustomerComponent.prototype.onUpdate = function (id) {
        this.toastr.success("Customer with id has been updated");
    };
    ActiveCustomerComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-activecustomer',
            template: __webpack_require__(/*! ./activecustomer.component.html */ "../src/app/customer/activecustomer.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_customer_service__WEBPACK_IMPORTED_MODULE_7__["CustomerService"]])
    ], ActiveCustomerComponent);
    return ActiveCustomerComponent;
}());



/***/ }),

/***/ "../src/app/customer/createcustomer.component.html":
/*!*********************************************************!*\
  !*** ../src/app/customer/createcustomer.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n <div class=\"content content-custom\">\n  <div class=\"card \">\n    <div class=\"card-header \">\n        <h4 class=\"card-title\">Create Customer </h4>\n    </div>\n    <div class=\"card-body \">\n      <div class=\"row\">\n       <div class=\"col-md-6\">\n        <form method=\"#\" action=\"#\">\n            <label>First Name</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"FirstName\" [(ngModel)]=\"customer.FirstName\"  class=\"form-control\">\n            </div>\n            <label>Middle Name</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"MiddleName\"  [(ngModel)]=\"customer.MiddleName\" class=\"form-control\">\n            </div>\n            <label>Email Address</label>\n            <div class=\"form-group\">\n                <input type=\"email\" name=\"EmailAddress\" [(ngModel)]=\"customer.EmailAddress\" class=\"form-control\">\n            </div>\n            <label> Customer Code </label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"CustomerCode\" [(ngModel)]=\"customer.CustomerCode\" class=\"form-control\" autocomplete=\"off\" >\n            </div>\n            <label>Mobile</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"Mobile\" [(ngModel)]=\"customer.Mobile\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n            <label>Username</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"UserId\" [(ngModel)]=\"customer.UserName\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n            <label>Next of Kin Name </label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"NokName\" [(ngModel)]=\"customer.NokName\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n            <label>Next of Kin Mobile </label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"NokMobile\" [(ngModel)]=\"customer.NokMobile\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n        </form>\n       </div>\n       <div class=\"col-md-6\">\n            <label>Last Name</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"LastName\"  [(ngModel)]=\"customer.LastName\" class=\"form-control\" required>\n            </div>\n            <label>Gender</label>\n            <select class=\"form-control form-control-sm\" name=\"gender\" [(ngModel)]=\"customer.Gender\">\n              <option selected=\"selected\" value=\"Male\">\n                  Male\n               </option>\n                <option value=\"Female\">\n                   Female\n               </option>\n            </select>\n            <label> Picture </label> <br/>\n            <div class=\"form-group\">\n                <div class=\"fileinput fileinput-new form-group\" data-provides=\"fileinput\">\n                    <span class=\"btn btn-default btn-file\">\n                        <span>Choose file</span>\n                        <input type=\"hidden\">\n                        <input  name=\"Picture\"  #file type=\"file\" multiple (change)=\"onFileChanged(file.files)\"  >\n                    </span>\n                    <span class=\"fileinput-filename\"></span>\n                    <span class=\"fileinput-new\">No file chosen</span>\n                </div>\n            </div>\n            <label> Signature </label> <br/>\n            <div class=\"fileinput fileinput-new form-group\" data-provides=\"fileinput\">\n              <span class=\"btn btn-default btn-file\">\n                  <span>Choose file</span> <input type=\"hidden\">\n                  <input  name=\"Signature\"  #sfile type=\"file\" multiple (change)=\"onsignatureFileChanged(sfile.files)\"  >\n              </span>\n              <span class=\"fileinput-filename\"></span>\n              <span class=\"fileinput-new\">No file chosen</span>\n          </div>\n            <div class=\"form-group\">\n                <input type=\"file\" name=\"Signature\" [(ngModel)]=\"customer.CustomerCode\" class=\"form-control\"  >\n            </div>\n            <label>City </label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"City\" [(ngModel)]=\"customer.City\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n            <label>State</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"State\" [(ngModel)]=\"customer.State\" class=\"form-control\" required>\n            </div>\n            <label>Address</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"Address\" [(ngModel)]=\"customer.Address\" class=\"form-control\" required>\n            </div>\n          </div>\n      </div>\n\n    </div>\n    <div class=\"card-footer \">\n        <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" (click)=\"Ok(customer)\" style=\"background-color: orange\">Save Customer </a>\n\n        &nbsp; <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" [routerLink]=\"['/customer']\" > Back to List </a>\n    </div>\n</div>\n</div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/customer/createcustomer.component.ts":
/*!*******************************************************!*\
  !*** ../src/app/customer/createcustomer.component.ts ***!
  \*******************************************************/
/*! exports provided: CreateCustomerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreateCustomerComponent", function() { return CreateCustomerComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _service_customer_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/customer.service */ "../src/app/service/customer.service.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var CreateCustomerComponent = /** @class */ (function () {
    function CreateCustomerComponent(router, toastr, storage, spinnerService, service, http) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.http = http;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.customer = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["Customer"]();
        this.formData = new FormData();
        this.sformData = new FormData(); // signature
    }
    CreateCustomerComponent.prototype.ngOnInit = function () {
    };
    // onsFileChanged(files: any) {
    //   if (!files) {
    //     this.toastr.error('Error, please check the file inputst');
    //     return;
    //   }
    //   for (const file of files) {
    //     this.sformData.append('signature', file);
    //     this.sfileName = file.name;
    //   }
    // }
    CreateCustomerComponent.prototype.onsignatureFileChanged = function (files) {
        if (!files) {
            this.toastr.error('Error, please check the file inputst');
            return;
        }
        for (var _i = 0, files_1 = files; _i < files_1.length; _i++) {
            var file = files_1[_i];
            this.formData.append('signature', file);
            this.fileName = file.name;
        }
    };
    CreateCustomerComponent.prototype.onFileChanged = function (files) {
        if (!files) {
            this.toastr.error('Error, please check the file inputst');
            return;
        }
        for (var _i = 0, files_2 = files; _i < files_2.length; _i++) {
            var file = files_2[_i];
            this.formData.append('picture', file);
            this.fileName = file.name;
        }
    };
    CreateCustomerComponent.prototype.Ok = function (model) {
        var _this = this;
        var self = this;
        this.service.CreateCustomer(model).subscribe(function (c) {
            if (c.Succeeded) {
                // Picture upload
                var req = new _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpRequest"]('POST', "api/v1/customer/image-upload/" + c.Result.CustomerId, self.formData, {
                    reportProgress: true,
                });
                self.http.request(req).subscribe(function (event) {
                    self.formData = new FormData();
                    if (event.type === _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpEventType"].UploadProgress) {
                        self.uploadProgress = Math.round(100 * event.loaded / event.total);
                        _this.spinnerService.show();
                    }
                    else if (event instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpResponse"]) {
                        console.log('Files uploaded!');
                    }
                    self.formData = new FormData();
                    _this.spinnerService.hide();
                    // self.toastr.success('Operation successful');
                });
                self.toastr.success('Operation successful');
            }
            else {
                self.toastr.error('Operation failed ' + c.Message);
            }
            self.formData = new FormData();
        });
    };
    CreateCustomerComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-createcustomer',
            template: __webpack_require__(/*! ./createcustomer.component.html */ "../src/app/customer/createcustomer.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"],
            _service_customer_service__WEBPACK_IMPORTED_MODULE_6__["CustomerService"], _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClient"]])
    ], CreateCustomerComponent);
    return CreateCustomerComponent;
}());



/***/ }),

/***/ "../src/app/customer/customer.component.html":
/*!***************************************************!*\
  !*** ../src/app/customer/customer.component.html ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">All Customer Report </h5>\n              <p>The list shows all the customers either <code>active</code>  or <code>inactive</code>\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" [routerLink]=\"['/createcustomer']\"><i class=\"fa fa-plus\"></i> Add Customer </a>\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" (click)=\"reloadPage()\">Refresh </a>\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control \" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchModel.Search\" type=\"text\">\n                          &nbsp; <span>StartDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"stardate\" name=\"stardate\" [(ngModel)]=\"searchModel.StartDate\" >\n                          &nbsp; <span>EndDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"enddate\" name=\"enddate\" [(ngModel)]=\"searchModel.EndDate\" >\n                          &nbsp;\n                          <a href=\"javascript:;\" class=\"btn btn btn-sm mb-2\" (click)=\"SearchCustomer(searchModel)\" style=\"background-color: orange\"><i class=\"fa fa-search\"></i>Search </a>\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>First Name</th>\n                              <th>Last Name</th>\n                              <th>Customer Code</th>\n                              <th>Phone Number</th>\n                             <th>Account Balance </th>\n                              <!-- <th>NOk Name </th>\n                              <th>NOk Phone No </th> -->\n                              <th>User Name </th>\n                              <th>Is Active </th>\n                              <th>Entry Date </th>\n                              <th>Action </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of customers ; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.FirstName}}</td>\n                              <td>{{item.LastName}}</td>\n                              <td>{{item.CustomerCode}} </td>\n                              <td>{{item.Mobile}}</td>\n                              <td>₦{{item.CustomerBalance | number}}</td>\n                              <!-- <td>{{item.NokName}}</td>\n                              <td>{{item.NokMobile}}</td> -->\n                              <td>{{item.UserName}}</td>\n                              <td>{{!item.Status ? 'InActive': 'Active'}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                                  <td class=\"td-actions text-left\">\n                                      <a href=\"javascript:;\"  *ngIf=\"roleName == 'Merchant Admin'\" class=\"btn btn-sm mb-3\" (click)=\"ResetBalance(item.CustomerId)\" style=\"background-color:orange\">Reset bal </a> &nbsp;\n                                      <a href=\"javascript:;\"   class=\"btn btn-sm mb-3\" (click)=\"GetCustomerView(item.CustomerId)\" style=\"background-color:\t#b2beb5\">View  </a> &nbsp;\n                                      <a href=\"javascript:;\"   class=\"btn btn-sm mb-3\" (click)=\"GetCustomerUpdate(item.CustomerId)\" style=\"background-color:\t#0000ff\">Update </a> &nbsp;\n                                      <!-- <button type=\"button\" (click)=\"onUpdate(item.CustomerId)\" rel=\"tooltip\" class=\"btn btn-info btn-simple btn-icon btn-sm\" data-original-title=\"\" title=\"\">\n                                          <i class=\"now-ui-icons users_single-02\"></i>\n                                      </button>\n                                      <button type=\"button\" rel=\"tooltip\" class=\"btn btn-success btn-simple btn-icon btn-sm\" data-original-title=\"\" title=\"\">\n                                          <i class=\"now-ui-icons ui-2_settings-90\"></i>\n                                      </button>\n                                      <button type=\"button\" rel=\"tooltip\" class=\"btn btn-danger btn-simple btn-icon btn-sm\" data-original-title=\"\" title=\"\">\n                                          <i class=\"now-ui-icons ui-1_simple-remove\"></i>\n                                      </button> -->\n                                  </td>\n                                  <!-- <i><a ><i class=\"fa fa-edit\" style=\"font-size:18px\"></i> </a></i>&nbsp; -->\n                                  <!-- <i><a ><i class=\"fa fa-edit\" style=\"font-size:18px\"></i> </a></i>&nbsp; -->\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <!-- <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No Customer found</span>\n                    </div> -->\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/customer/customer.component.ts":
/*!*************************************************!*\
  !*** ../src/app/customer/customer.component.ts ***!
  \*************************************************/
/*! exports provided: CustomerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerComponent", function() { return CustomerComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_customer_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/customer.service */ "../src/app/service/customer.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var CustomerComponent = /** @class */ (function () {
    function CustomerComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.dashboard = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["DashboardModel"]();
        this.customers = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.searchModel = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["SearchModel"]();
    }
    CustomerComponent.prototype.reloadPage = function () {
        document.location.reload();
    };
    CustomerComponent.prototype.ngOnInit = function () {
        this.roleName = this.storage.GetUserInfo().Role;
        this.LoadFirstPage();
    };
    CustomerComponent.prototype.GetStatus = function (status) { };
    CustomerComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    CustomerComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get(Math.ceil(this.data.SequenceLength / this.pageSize) - 1);
        }
    };
    CustomerComponent.prototype.HasNoPage = function () {
        var result = this.data == null ||
            typeof this.data === "undefined" ||
            this.data.Page.length === 0;
        return result;
    };
    CustomerComponent.prototype.SearchCustomer = function (searchMod) {
        var self = this;
        self.service.getCustomerSeach(searchMod).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.customers = self.data.Page;
            }
            return self.customers;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.customers;
        });
        return self.customers;
    };
    CustomerComponent.prototype.Get = function (pageIndex) {
        var self = this;
        this.searchModel.pageSize = this.pageSize;
        this.searchModel.pageIndex = pageIndex;
        self.service.getCustomerSeach(this.searchModel).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.customers = self.data.Page;
            }
            return self.customers;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.customers;
        });
        return self.customers;
    };
    CustomerComponent.prototype.ResetBalance = function (id) {
        var _this = this;
        var self = this;
        if (!confirm("Are you sure")) {
            self.toastr.success("Customer balance reset operation cancelled successfully", "Success");
            return;
        }
        this.service.resetCustomerBalance(id).subscribe(function (c) {
            if (c.Succeeded) {
                self.toastr.success("Operation Succesful", "Success");
                _this.LoadFirstPage();
            }
            else {
                self.toastr.error(c.Message, "Error");
            }
        });
    };
    CustomerComponent.prototype.onUpdate = function (id) {
        this.toastr.success("Customer with id has been updated");
    };
    CustomerComponent.prototype.GetCustomerView = function (id) {
        this.router.navigate(["/customer-view", id]);
    };
    CustomerComponent.prototype.GetCustomerUpdate = function (id) {
        this.router.navigate(["/customer-update", id]);
    };
    CustomerComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-customer",
            template: __webpack_require__(/*! ./customer.component.html */ "../src/app/customer/customer.component.html")
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"],
            _service_customer_service__WEBPACK_IMPORTED_MODULE_7__["CustomerService"]])
    ], CustomerComponent);
    return CustomerComponent;
}());



/***/ }),

/***/ "../src/app/customer/inactivecustomer.component.html":
/*!***********************************************************!*\
  !*** ../src/app/customer/inactivecustomer.component.html ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">In Active Customer List</h5>\n              <p>The list shows all the   <code>inactive</code> customers\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control form-control-sm mar-5\" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchString\" type=\"text\">\n                          <!-- <select class=\"form-control form-control-sm\">\n                              <option selected=\"selected\" value=\"\">\n                                  Select Status\n                              </option>\n                              <option value=\"Pending\">\n                                  Pending\n                              </option>\n                              <option value=\"Completed\">\n                                  Completed\n                              </option>\n                              <option value=\"Cancelled\">\n                                  Cancelled\n                              </option>\n                          </select> -->\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered\">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>First Name</th>\n                              <th>Last Name</th>\n                              <th>Customer Code</th>\n                              <th>Phone Number</th>\n                              <th>User Name </th>\n                              <th>Customer Balance </th>\n\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of customers ; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.FirstName}}</td>\n                              <td>{{item.LastName}}</td>\n                              <td>{{item.CustomerCode}} </td>\n                              <td>{{item.Mobile}}</td>\n                              <td>{{item.UserName}}</td>\n                              <td>₦{{item.CustomerBalance | number}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                          </tr>\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No Customer found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li><a href=\"javascript:void(0)\" style=\"font-size:18px;background-color:darkblue\" (click)=\"LoadFirstPage()\">&laquo;</a></li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li><a href=\"javascript:void(0)\" (click)=\"LoadLastPage()\" style=\"font-size:18px;background-color:darkblue\">&raquo;</a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/customer/inactivecustomer.component.ts":
/*!*********************************************************!*\
  !*** ../src/app/customer/inactivecustomer.component.ts ***!
  \*********************************************************/
/*! exports provided: InActiveCustomerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "InActiveCustomerComponent", function() { return InActiveCustomerComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_customer_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/customer.service */ "../src/app/service/customer.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var InActiveCustomerComponent = /** @class */ (function () {
    function InActiveCustomerComponent(router, toastr, storage, spinnerService, customer) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.customer = customer;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.dashboard = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["DashboardModel"]();
        this.customers = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
    }
    InActiveCustomerComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    InActiveCustomerComponent.prototype.GetStatus = function (status) {
    };
    InActiveCustomerComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    InActiveCustomerComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    InActiveCustomerComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0 || this.customers.length === 0;
        return result;
    };
    InActiveCustomerComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.customer.getInActiveCustomers(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.customers = self.data.Page;
            }
            return self.customers;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.customers;
        });
        return self.customers;
    };
    InActiveCustomerComponent.prototype.onUpdate = function (id) {
        this.toastr.success("Customer with id has been updated");
    };
    InActiveCustomerComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-inactivecustomer',
            template: __webpack_require__(/*! ./inactivecustomer.component.html */ "../src/app/customer/inactivecustomer.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_customer_service__WEBPACK_IMPORTED_MODULE_7__["CustomerService"]])
    ], InActiveCustomerComponent);
    return InActiveCustomerComponent;
}());



/***/ }),

/***/ "../src/app/customer/updatecustomer.component.html":
/*!*********************************************************!*\
  !*** ../src/app/customer/updatecustomer.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n <div class=\"content content-custom\">\n  <div class=\"card \">\n    <div class=\"card-header \">\n        <h4 class=\"card-title\">Update Customer </h4>\n    </div>\n    <div class=\"card-body \">\n      <div class=\"row\">\n       <div class=\"col-md-6\">\n        <form method=\"#\" action=\"#\">\n            <label>First Name</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"FirstName\" [(ngModel)]=\"customer.FirstName\"  class=\"form-control\">\n            </div>\n            <label>Middle Name</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"MiddleName\"  [(ngModel)]=\"customer.MiddleName\" class=\"form-control\">\n            </div>\n            <label>Email Address</label>\n            <div class=\"form-group\">\n                <input type=\"email\" name=\"EmailAddress\" [(ngModel)]=\"customer.EmailAddress\" class=\"form-control\">\n            </div>\n\n            <label>Mobile</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"Mobile\" [(ngModel)]=\"customer.Mobile\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n            <label>Username</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"UserId\" [(ngModel)]=\"customer.UserName\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n            <label>Next of Kin Name </label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"NokName\" [(ngModel)]=\"customer.NokName\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n            <label>Next of Kin Mobile </label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"NokMobile\" [(ngModel)]=\"customer.NokMobile\" class=\"form-control\" autocomplete=\"off\">\n            </div>\n        </form>\n       </div>\n       <div class=\"col-md-6\">\n         <form method=\"#\" action=\"#\">\r\n           <label>Last Name</label>\r\n           <div class=\"form-group\">\r\n             <input type=\"text\" name=\"LastName\" [(ngModel)]=\"customer.LastName\" class=\"form-control\" required>\r\n           </div>\r\n           <label>Gender</label>\r\n           <select class=\"form-control form-control-sm\" name=\"gender\" [(ngModel)]=\"customer.Gender\">\r\n             <option selected=\"selected\" value=\"Male\">\r\n               Male\r\n             </option>\r\n             <option value=\"Female\">\r\n               Female\r\n             </option>\r\n           </select>\r\n           <label>Customer Code </label>\r\n           <div class=\"form-group\">\r\n             <input type=\"text\" name=\"CustomerCode\" [(ngModel)]=\"customer.CustomerCode\" class=\"form-control\" autocomplete=\"off\">\r\n           </div>\r\n           <label> Picture </label> <br />\r\n           <div class=\"form-group\">\r\n             <div class=\"fileinput fileinput-new form-group\" data-provides=\"fileinput\">\r\n               <span class=\"btn btn-default btn-file\">\r\n                 <span>Choose file</span>\r\n                 <input type=\"hidden\">\r\n                 <input name=\"Picture\" #file type=\"file\" multiple (change)=\"onFileChanged(file.files)\">\r\n               </span>\r\n               <span class=\"fileinput-filename\"></span>\r\n               <span class=\"fileinput-new\">No file chosen</span>\r\n             </div>\r\n           </div>\r\n           <label> Signature </label> <br />\r\n           <div class=\"fileinput fileinput-new form-group\" data-provides=\"fileinput\">\r\n             <span class=\"btn btn-default btn-file\">\r\n               <span>Choose file</span> <input type=\"hidden\">\r\n               <input name=\"Signature\" #sfile type=\"file\" multiple (change)=\"onsignatureFileChanged(sfile.files)\">\r\n             </span>\r\n             <span class=\"fileinput-filename\"></span>\r\n             <span class=\"fileinput-new\">No file chosen</span>\r\n           </div>\r\n           <label>City </label>\r\n           <div class=\"form-group\">\r\n             <input type=\"text\" name=\"City\" [(ngModel)]=\"customer.City\" class=\"form-control\" autocomplete=\"off\">\r\n           </div>\r\n           <label>State</label>\r\n           <div class=\"form-group\">\r\n             <input type=\"text\" name=\"State\" [(ngModel)]=\"customer.State\" class=\"form-control\" required>\r\n           </div>\r\n           <label>Address</label>\r\n           <div class=\"form-group\">\r\n             <input type=\"text\" name=\"Address\" [(ngModel)]=\"customer.Address\" class=\"form-control\" required>\r\n           </div>\r\n         </form>\n       </div>\n      </div>\n\n    </div>\n    <div class=\"card-footer \">\n        <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" (click)=\"Update()\" style=\"background-color: orange\">Update Customer </a>\n\n        &nbsp; <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" [routerLink]=\"['/customer']\" > Back to List </a>\n    </div>\n</div>\n</div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/customer/updatecustomer.component.ts":
/*!*******************************************************!*\
  !*** ../src/app/customer/updatecustomer.component.ts ***!
  \*******************************************************/
/*! exports provided: UpdateCustomerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UpdateCustomerComponent", function() { return UpdateCustomerComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _service_customer_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/customer.service */ "../src/app/service/customer.service.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var UpdateCustomerComponent = /** @class */ (function () {
    function UpdateCustomerComponent(router, route, toastr, storage, spinnerService, service, http) {
        this.router = router;
        this.route = route;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.http = http;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.dashboard = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["DashboardModel"]();
        this.customers = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.customer = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["Customer"]();
        this.formData = new FormData();
        this.sformData = new FormData(); // signature
        var cid = this.route.snapshot.paramMap.get('id');
        if (cid !== null) {
            this.customerId = Number(cid);
        }
    }
    UpdateCustomerComponent.prototype.ngOnInit = function () {
        var self = this;
        this.service.GetCustomer(this.customerId).subscribe(function (c) {
            if (c.Succeeded) {
                self.customer = c.Result;
            }
            else {
                self.toastr.error(c.Message, 'Error ');
            }
        }, function (e) {
            self.toastr.error('Operation failed ' + e, 'Error');
        });
    };
    UpdateCustomerComponent.prototype.onsignatureFileChanged = function (files) {
        if (!files) {
            this.toastr.error('Error, please check the file inputst');
            return;
        }
        for (var _i = 0, files_1 = files; _i < files_1.length; _i++) {
            var file = files_1[_i];
            this.formData.append('signature', file);
            this.fileName = file.name;
        }
    };
    UpdateCustomerComponent.prototype.onFileChanged = function (files) {
        if (!files) {
            this.toastr.error('Error, please check the file inputst');
            return;
        }
        for (var _i = 0, files_2 = files; _i < files_2.length; _i++) {
            var file = files_2[_i];
            this.formData.append('picture', file);
            this.fileName = file.name;
        }
    };
    UpdateCustomerComponent.prototype.Update = function () {
        var _this = this;
        var self = this;
        this.service.UpdateCustomer(this.customer).subscribe(function (c) {
            if (c.Succeeded) {
                // Picture upload
                var req = new _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpRequest"]('POST', "api/v1/customer/image-upload/" + c.Result.CustomerId, self.formData, {
                    reportProgress: true,
                });
                self.http.request(req).subscribe(function (event) {
                    self.formData = new FormData();
                    if (event.type === _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpEventType"].UploadProgress) {
                        self.uploadProgress = Math.round(100 * event.loaded / event.total);
                        _this.spinnerService.show();
                    }
                    else if (event instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpResponse"]) {
                        console.log('Files uploaded!');
                    }
                    self.formData = new FormData();
                    _this.spinnerService.hide();
                    // self.toastr.success('Operation successful');
                });
                self.toastr.success('Operation successful');
            }
            else {
                self.toastr.error(c.Message, 'Error');
            }
            self.formData = new FormData();
        }, function (e) {
            self.toastr.error('Operation failed' + e, 'Error');
        });
    };
    UpdateCustomerComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-updatecustomer',
            template: __webpack_require__(/*! ./updatecustomer.component.html */ "../src/app/customer/updatecustomer.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"],
            _service_customer_service__WEBPACK_IMPORTED_MODULE_6__["CustomerService"], _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClient"]])
    ], UpdateCustomerComponent);
    return UpdateCustomerComponent;
}());



/***/ }),

/***/ "../src/app/customer/viewcustomer.component.html":
/*!*******************************************************!*\
  !*** ../src/app/customer/viewcustomer.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n <div class=\"content content-custom\">\n  <div class=\"card \">\n    <div class=\"card-header \">\n        <h4 class=\"card-title\">View Customer </h4>\n    </div>\n    <div class=\"card-body \">\n      <div class=\"row\">\n       <div class=\"col-md-6\">\n        <form method=\"#\" action=\"#\">\n            <label>First Name</label>\n            <div class=\"form-group\">\n              {{ customer.FirstName }}\n            </div>\n            <label>Middle Name</label>\n            <div class=\"form-group\">\n              {{ customer.MiddleName }}\n            </div>\n            <label>Email Address</label>\n            <div class=\"form-group\">\n              {{ customer.EmailAddress }}\n            </div>\n\n            <label>Mobile</label>\n            <div class=\"form-group\">\n              {{ customer.Mobile }}\n            </div>\n            <label>Username</label>\n            <div class=\"form-group\">\n              {{ customer.UserName }}\n            </div>\n            <label>Customer Code </label>\n            <div class=\"form-group\">\n              {{ customer.CustomerCode }}\n            </div>\n            <label>Next of Kin Name </label>\n            <div class=\"form-group\">\n              {{ customer.NokName }}\n            </div>\n            <label>Next of Kin Mobile </label>\n            <div class=\"form-group\">\n              {{ customer.NokMobile }}\n            </div>\n            <label>Entry Date </label>\n            <div class=\"form-group\">\n              {{ customer.CreatedDate | date }}\n            </div>\n        </form>\n       </div>\n       <div class=\"col-md-6\">\n        <form method=\"#\" action=\"#\">\n            <label>Last Name</label>\n            <div class=\"form-group\">\n              {{ customer.LastName }}\n            </div>\n            <label>Gender</label>\n            <div class=\"form-group\">\n            {{ customer.Gender }}\n            </div>\n            <label>Customer Code</label>\n            <div class=\"form-group\">\n            {{ customer.CustomerCode }}\n          </div>\n            <label>City </label>\n            <div class=\"form-group\">\n              {{ customer.City }}\n            </div>\n            <label>State</label>\n            <div class=\"form-group\">\n              {{ customer.State }}\n            </div>\n            <label>Address</label>\n            <div class=\"form-group\">\n              {{ customer.Address }}\n            </div>\n            <label>Current Balance</label>\n            <div class=\"form-group\">\n                ₦{{ customer.CustomerBalance | number }}\n            </div>\n            <label>Signature</label>\n            <div class=\"form-group\">\n              <img src=\"{{ customer.SignaturePath }}\" alt=\"Signature\" width=\"100px\" height=\"80px\">\n            </div>\n            <label>Picture</label>\n            <div class=\"form-group\">\n              <img src=\"{{ customer.PicturePath }}\" alt=\"picture\" width=\"100px\" height=\"80px\">\n            </div>\n        </form>\n       </div>\n      </div>\n\n    </div>\n    <div class=\"card-footer \">\n        <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" [routerLink]=\"['/customer-update',customer.CustomerId]\"  style=\"background-color: orange\">Edit Customer </a>\n        &nbsp; <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" [routerLink]=\"['/customer']\" > Back to List </a>\n    </div>\n</div>\n</div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/customer/viewcustomer.component.ts":
/*!*****************************************************!*\
  !*** ../src/app/customer/viewcustomer.component.ts ***!
  \*****************************************************/
/*! exports provided: ViewCustomerComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ViewCustomerComponent", function() { return ViewCustomerComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _service_customer_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/customer.service */ "../src/app/service/customer.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ViewCustomerComponent = /** @class */ (function () {
    function ViewCustomerComponent(router, route, toastr, storage, spinnerService, service) {
        this.router = router;
        this.route = route;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.dashboard = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["DashboardModel"]();
        this.customers = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.customer = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["Customer"]();
        var self = this;
        var cid = this.route.snapshot.paramMap.get('id');
        if (cid !== null) {
            this.service.GetCustomer(Number(cid)).subscribe(function (c) {
                if (c.Succeeded) {
                    self.customer = c.Result;
                }
                else {
                    self.toastr.error(c.Message, 'Error ');
                }
            }, function (e) {
                self.toastr.error('Operation failed ' + e, 'Error');
            });
        }
    }
    ViewCustomerComponent.prototype.ngOnInit = function () {
    };
    ViewCustomerComponent.prototype.GetStatus = function (status) {
    };
    ViewCustomerComponent.prototype.onUpdate = function (id) {
        this.toastr.success("Customer with id has been updated");
    };
    ViewCustomerComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-viewcustomer',
            template: __webpack_require__(/*! ./viewcustomer.component.html */ "../src/app/customer/viewcustomer.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_customer_service__WEBPACK_IMPORTED_MODULE_6__["CustomerService"]])
    ], ViewCustomerComponent);
    return ViewCustomerComponent;
}());



/***/ }),

/***/ "../src/app/dashboard/dashboard.component.css":
/*!****************************************************!*\
  !*** ../src/app/dashboard/dashboard.component.css ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "../src/app/dashboard/dashboard.component.html":
/*!*****************************************************!*\
  !*** ../src/app/dashboard/dashboard.component.html ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"min-height: 800px\" >\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n     <!-- <canvas id=\"bigDashboardChart\"></canvas> -->\n </div>\n     <!-- Piechart and Line Chart -->\n     <div class=\"content content-custom\" >\n         <div class=\"row\">\n             <div class=\"col-md-3\">\n                 <div class=\"card\">\n                     <div class=\"card-body card-body-custom\">\n                         <div class=\"text-center\">\n                             <div class=\"piechart\" data-percent=\"40\">\n                                 <!-- <span class=\"percent\">40%</span> -->\n                                 <i class=\"fa fa-handshake-o\" aria-hidden=\"true\"></i>\n                             <canvas height=\"150\" width=\"150\" style=\"height: 60px; width: 60px;\"></canvas></div>\n\n                            <span style=\"text-align: center\">\n                              <h6 style=\"color: blue\">Total Merchant Balance <br/> <b> ₦{{dashboard.TotalMerchantBalance | number}}</b> </h6>\n                              <h6 style=\"color: orange\">Daily Debit Balance <br/> <b> ₦{{dashboard.TotalDailyDebit | number}}</b> </h6>\n                            </span>\n                         </div>\n                     </div>\n                 </div>\n             </div>\n             <div class=\"col-md-3\">\n                 <div class=\"card\">\n                     <div class=\"card-body card-body-custom\">\n                         <div class=\"text-left\">\n                             <div class=\"piechart\" data-percent=\"59\">\n                                 <!-- <span class=\"percent\">59%</span> -->\n                             <canvas height=\"150\" width=\"150\" style=\"height: 60px; width: 60px;\"></canvas></div>\n                            <span style=\"text-align: center\">\n                               <h6 style=\"color: blue\">Daily Credit Balance  <br/> <b>  ₦{{dashboard.TotalDailyCredit  | number }}</b> </h6>\n                               <h6 style=\"color: orange\">Weekly Debit Balance  <br/> <b> ₦{{dashboard.TotalWeeklyDebit  | number }} </b> </h6>\n                            </span>\n                         </div>\n                     </div>\n                 </div>\n             </div>\n             <div class=\"col-md-3\">\n                 <div class=\"card\">\n                     <div class=\"card-body card-body-custom\">\n                         <div class=\"text-left\">\n                             <div class=\"piechart\" data-percent=\"90\">\n                                 <!-- <span class=\"percent\">90%</span> -->\n                             <canvas height=\"150\" width=\"150\" style=\"height: 60px; width: 60px;\"></canvas></div>\n                            <span style=\"text-align: center\">\n                               <h6 style=\"color: blue\">Weekly Credit Balance <br/> <b>  ₦{{dashboard.TotalWeeklyCredit | number }} </b> </h6>\n                               <h6 style=\"color: orange\">Monthly Credit Balance <br/> <b> ₦{{dashboard.TotalMonthlyCredit | number}} </b></h6>\n                            </span>\n                         </div>\n                     </div>\n                 </div>\n             </div>\n             <div class=\"col-md-3\">\n                 <div class=\"card\">\n                     <div class=\"card-body card-body-custom\">\n                         <div class=\"text-left\">\n                             <div class=\"piechart\" data-percent=\"32\">\n                                 <!-- <span class=\"percent\">32%</span> -->\n                             <canvas height=\"150\" width=\"150\" style=\"height: 60px; width: 60px;\"></canvas></div>\n                            <span style=\"text-align: center\">\n                              <h6 style=\"color: blue;\">Total Active Customer <br/> <b> {{dashboard.TotalActiveCustomers | number }} </b> </h6>\n                              <h6 style=\"color: orange\">Total Customer Today <br/> <b> {{dashboard.TotalCustomerToday | number }} </b> </h6>\n                            </span>\n                         </div>\n                     </div>\n                 </div>\n             </div>\n         </div>\n\n         <div class=\"row\"   >\n          <div class=\"col-md-6\" >\n              <div class=\"card\" >\n                  <div class=\"card-header\">\n                      <h5 class=\"title\">Last 10 Transactions</h5>\n                  </div>\n                  <div class=\"card-body card-body-custom\"  style=\"overflow: scroll\" >\n                      <table class=\"table table-bordered \" >\n                          <thead>\n                              <tr class=\"h6\">\n                                  <th class=\"text-center\">Customer Code</th>\n                                  <th class=\"text-center\">Transaction No</th>\n                                  <th class=\"text-center\">Transaction Type</th>\n                                  <th class=\"text-center\">Amount</th>\n                                  <th class=\"text-center\">Transaction Date</th>\n                              </tr>\n                          </thead>\n                          <tbody>\n                              <tr *ngFor=\"let item of dashboard.LastTenTransaction;let i=index\" style=\"font-size: 12px\">\n                                  <td class=\"text-center\">{{item.Customer.FirstName}} {{item.Customer.LastName}} </td>\n                                  <td class=\"text-center\">{{item.TransactionNo}}</td>\n                                  <td class=\"text-center\">{{item.TransactionType}}</td>\n                                  <td class=\"text-center\">₦{{item.Amount}}</td>\n                                  <td class=\"text-center\">{{item.CreatedDate | date}}</td>\n                              </tr>\n                          </tbody>\n                      </table>\n                  </div>\n              </div>\n\n          </div>\n          <div class=\"col-md-6\" >\n            <div class=\"card\">\n              <div class=\"card-header\">\n                  <h5 class=\"title\">Last 10 withdrawal</h5>\n              </div>\n              <div class=\"card-body card-body-custom\" style=\"overflow: scroll\" >\n                  <table class=\"table table-bordered \" >\n                      <thead>\n                          <tr class=\"h6\">\n                              <th class=\"text-center\">Customer Name</th>\n                              <th class=\"text-center\">Amount</th>\n                              <th class=\"text-center\">Withdrawal Status</th>\n                              <th class=\"text-center\">Entry Date</th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr style=\"font-size: 12px\" *ngFor=\"let item of dashboard.LastTenWithdrawal;let i=index\">\n                              <td class=\"text-center\">{{ item.Customer.LastName }} {{item.Customer.FirstName}}</td>\n                              <td class=\"text-center\">₦{{item.Amount }}</td>\n                              <td class=\"text-center\">{{GetWithdrawalStatus(item.WithdrawalStatus)}}</td>\n                              <td class=\"text-center\">{{item.CreatedDate | date}} </td>\n                          </tr>\n                      </tbody>\n                  </table>\n              </div>\n          </div>\n          </div>\n        </div>\n      </div>\n\n    </div>\n\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/dashboard/dashboard.component.ts":
/*!***************************************************!*\
  !*** ../src/app/dashboard/dashboard.component.ts ***!
  \***************************************************/
/*! exports provided: DashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DashboardComponent", function() { return DashboardComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_Constants__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/Constants */ "../src/app/shared/Constants.ts");
/* harmony import */ var _service_report_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/report.service */ "../src/app/service/report.service.ts");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









var DashboardComponent = /** @class */ (function () {
    function DashboardComponent(request, router, toastr, storage, spinnerService, report) {
        this.request = request;
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.report = report;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.dashboard = new _shared_model__WEBPACK_IMPORTED_MODULE_7__["DashboardModel"]();
        // , @Inject(DOCUMENT) private document: any
    }
    DashboardComponent.prototype.ngAfterViewInit = function () { };
    DashboardComponent.prototype.ngOnInit = function () {
        try {
            this.spinnerService.show();
            var self_1 = this;
            // const token = this.storage.Token;
            var _token = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_5__["Constants"].OAuthTokenKey);
            if (_token != null) {
                self_1.GetDashboard();
                this.router.navigate([""]);
            }
            else {
                this.router.navigate(["/login"]);
            }
            this.spinnerService.hide();
        }
        catch (e) {
            this.spinnerService.hide();
            console.log(this.baseurl + "#/login");
            document.location.href = this.baseurl + "#/login";
            this.router.navigate(["/login"]);
        }
    };
    DashboardComponent.prototype.GetDashboard = function () {
        var self = this;
        this.report.GetDashboard().subscribe(function (c) {
            self.dashboard = c.Result;
        });
    };
    DashboardComponent.prototype.GetWithdrawalStatus = function (status) {
        if (status === 0) {
            return "Pending";
        }
        else if (status === 1) {
            return "Approved";
        }
        else if (status === 2) {
            return "Paid";
        }
    };
    DashboardComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-dashboard",
            template: __webpack_require__(/*! ./dashboard.component.html */ "../src/app/dashboard/dashboard.component.html"),
            styles: [__webpack_require__(/*! ./dashboard.component.css */ "../src/app/dashboard/dashboard.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_8__["HttpRequest"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"],
            _service_report_service__WEBPACK_IMPORTED_MODULE_6__["ReportService"]])
    ], DashboardComponent);
    return DashboardComponent;
}());



/***/ }),

/***/ "../src/app/feecharges/smsdebit.component.html":
/*!*****************************************************!*\
  !*** ../src/app/feecharges/smsdebit.component.html ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\" data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n    <app-topnav></app-topnav>\n    <div class=\"panel-header panel-header-sm panel-header-custom\">\n    </div>\n    <div class=\"content content-custom\">\n      <div class=\"card\">\n        <div class=\"card-header\">\n          <h5 class=\"title\">Sms Notification</h5>\n          <!-- <p>The list shows all the transaction either <code>credit</code>  or <code>debit</code>\n          </p>-->\n          <hr>\n          <div class=\"row\">\n            <div class=\"col-sm-3\">\n              <span style=\"color: orange\">\n                <h5> Total Sms Count: {{smsmodel.NotifyCount}} </h5>\n              </span> &nbsp;\n            </div>\n            <div class=\"col-sm-3\">\n              <span style=\"color: orange\">\n                <h5>Total Sms Cost: ₦{{smsmodel.SmsCost}} </h5>\n              </span> &nbsp;\n            </div>\n            <div class=\"col-sm-6\">\n              <form class=\"form-inline justify-content-sm-end\">\n                <input class=\"form-control form-control-sm mar-5\" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchString\"\n                  type=\"text\">\n\n              </form>\n            </div>\n          </div>\n        </div>\n        <div class=\"card-body\">\n          <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n            <table class=\"table table-bordered\">\n              <thead>\n                <tr class=\"h6\">\n                  <th>SN</th>\n                  <th>Customer Name</th>\n                  <th>Sender Name</th>\n                  <th>Message</th>\n                  <th>Notification Date</th>\n                  <th>Total Message Sent</th>\n                  <th>Total Cost</th>\n                  <!-- <th>Is Paid</th> -->\n                  <th>Recipient </th>\n                </tr>\n              </thead>\n              <tbody>\n                <tr *ngFor=\"let item of smsmodel.Notifications; let i=index \">\n                  <td>{{i+1}}</td>\n                  <td>{{item.CustomerName}}</td>\n                  <td>{{item.Sender}}</td>\n                  <td>{{item.Message}} </td>\n                  <td>{{item.CreatedDate | date}}</td>\n                  <td>{{item.TotalMessageSent}}</td>\n                  <td>₦{{item.Cost}}</td>\n                  <!-- <td>{{item.IsPaid}}</td> -->\n                  <td>{{item.Recipient }}</td>\n                </tr>\n\n              </tbody>\n            </table>\n          </div>\n        </div>\n      </div>\n    </div>\n\n  </div>\n</div>\n"

/***/ }),

/***/ "../src/app/feecharges/smsdebit.component.ts":
/*!***************************************************!*\
  !*** ../src/app/feecharges/smsdebit.component.ts ***!
  \***************************************************/
/*! exports provided: SmsDebitComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SmsDebitComponent", function() { return SmsDebitComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _service_report_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../service/report.service */ "../src/app/service/report.service.ts");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_transaction_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../service/transaction.service */ "../src/app/service/transaction.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









var SmsDebitComponent = /** @class */ (function () {
    function SmsDebitComponent(router, toastr, storage, spinnerService, service, report) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.report = report;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.transactions = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.smsmodel = new _shared_model__WEBPACK_IMPORTED_MODULE_6__["SmsNotificationModel"]();
    }
    SmsDebitComponent.prototype.ngOnInit = function () {
        this.GetSmsNotification();
        this.LoadFirstPage();
    };
    SmsDebitComponent.prototype.GetStatus = function (status) { };
    SmsDebitComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    SmsDebitComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get(Math.ceil(this.data.SequenceLength / this.pageSize) - 1);
        }
    };
    SmsDebitComponent.prototype.HasNoPage = function () {
        var result = this.data == null ||
            typeof this.data === "undefined" ||
            this.data.Page.length === 0;
        return result;
    };
    SmsDebitComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getTransaction(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_7__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.transactions = self.data.Page;
            }
            return self.transactions;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_7__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.transactions;
        });
        return self.transactions;
    };
    SmsDebitComponent.prototype.GetSmsNotification = function () {
        var self = this;
        self.report.GetSmsNotification().subscribe(function (c) {
            self.smsmodel = c.Result;
        });
    };
    SmsDebitComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-smsdebit",
            template: __webpack_require__(/*! ./smsdebit.component.html */ "../src/app/feecharges/smsdebit.component.html")
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"],
            _service_transaction_service__WEBPACK_IMPORTED_MODULE_8__["TransactionService"],
            _service_report_service__WEBPACK_IMPORTED_MODULE_5__["ReportService"]])
    ], SmsDebitComponent);
    return SmsDebitComponent;
}());



/***/ }),

/***/ "../src/app/service/account.service.ts":
/*!*********************************************!*\
  !*** ../src/app/service/account.service.ts ***!
  \*********************************************/
/*! exports provided: AccountService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AccountService", function() { return AccountService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _data_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./data.service */ "../src/app/service/data.service.ts");
/* harmony import */ var _storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var AccountService = /** @class */ (function () {
    function AccountService(data, storage) {
        this.data = data;
        this.storage = storage;
    }
    // Get token
    AccountService.prototype.getUserToken = function (user) {
        var url = '/api/v1/account/login';
        var result = this.data.PostWithOutToken(url, user);
        return result;
    };
    // user registration
    AccountService.prototype.userLogin = function (model) {
        var url = "/api/v1/account/register";
        var r = this.data.Post(url, model);
        return r;
    };
    AccountService.prototype.getUsers = function () {
        return this.data.Get('/api/account/users');
    };
    // get user by user id
    AccountService.prototype.getUser = function (userId) {
        var url = "/api/v1/account/user/" + userId;
        var r = this.data.Get(url);
        return r;
    };
    // get user by user id
    AccountService.prototype.getCurrentUser = function () {
        var url = "/api/v1/account/current-user";
        var r = this.data.Get(url);
        return r;
    };
    // delete funtnx
    AccountService.prototype.deleteUser = function (id) {
        var url = '/api/v1/account/' + id;
        return this.data.Delete(url);
    };
    // register user
    AccountService.prototype.registerUser = function (model) {
        var url = '/api/v1/account/register';
        return this.data.Post(url, model);
    };
    // update profile
    AccountService.prototype.updateProfile = function (model) {
        var url = "/api/v1/account/update-profile";
        return this.data.Put(url, model);
    };
    // update profile
    AccountService.prototype.updateWebProfile = function (model) {
        var url = "/api/v1/account/update-userprofile";
        return this.data.Put(url, model);
    };
    // change password ..
    AccountService.prototype.changepassword = function (model) {
        var url = "/api/v1/account/change-password";
        return this.data.Put(url, model);
    };
    AccountService.prototype.registerCentralAdmin = function (model) {
        var url = "/api/v1/account/register";
        return this.data.Post(url, model);
    };
    // get user list..
    AccountService.prototype.getRegisterUser = function (pageIndex, pageSize) {
        var url = "/api/v1/account/" + pageIndex + "/all/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    // get user list..
    AccountService.prototype.getUserList = function (pageIndex, pageSize) {
        var url = "/api/v1/account/" + pageIndex + "/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    // get user list..
    AccountService.prototype.getUserAdminList = function (model) {
        var url = "/api/v1/account/customer-users";
        var result = this.data.Post(url, model);
        return result;
    };
    AccountService.prototype.getAgentUserdata = function (pageIndex, pageSize) {
        var url = "/api/v1/account/" + pageIndex + "/agent/" + pageSize;
        console.log(url);
        var result = this.data.Get(url);
        console.log(result);
        return result;
    };
    AccountService.prototype.ChangePasswordOk = function (model) {
        var url = "/api/v1/account/change-password";
        var result = this.data.Put(url, model);
        return result;
    };
    AccountService.prototype.GetAdminUser = function () {
        var url = "/api/v1/account/admin-users-data";
        var result = this.data.Get(url);
        return result;
    };
    AccountService.prototype.GetAdminUserPaged = function (pageIndex, pageSize) {
        var url = "/api/v1/account/admin-users-data/" + pageIndex + "/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    AccountService.prototype.GetAdminUserSearch = function (model) {
        var url = "/api/v1/account/admin-records";
        var result = this.data.Post(url, model);
        return result;
    };
    AccountService.prototype.CreateUser = function (model) {
        var url = "/api/v1/account/register-user";
        model.IsActive = true;
        var result = this.data.Post(url, model);
        return result;
    };
    AccountService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_data_service__WEBPACK_IMPORTED_MODULE_1__["DataService"], _storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"]])
    ], AccountService);
    return AccountService;
}());



/***/ }),

/***/ "../src/app/service/customer.service.ts":
/*!**********************************************!*\
  !*** ../src/app/service/customer.service.ts ***!
  \**********************************************/
/*! exports provided: CustomerService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CustomerService", function() { return CustomerService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _data_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./data.service */ "../src/app/service/data.service.ts");
/* harmony import */ var _storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var CustomerService = /** @class */ (function () {
    function CustomerService(data, storage) {
        this.data = data;
        this.storage = storage;
    }
    CustomerService.prototype.getCustomerSeach = function (model) {
        var url = "/api/v1/customer/records";
        var result = this.data.Post(url, model);
        return result;
    };
    CustomerService.prototype.getCustomers = function (pageIndex, pageSize) {
        var url = "/api/v1/customer/" + pageIndex + "/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    CustomerService.prototype.getActiveCustomers = function (pageIndex, pageSize) {
        var url = "/api/v1/customer/" + pageIndex + "/active/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    CustomerService.prototype.getInActiveCustomers = function (pageIndex, pageSize) {
        var url = "/api/v1/customer/" + pageIndex + "/in-active/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    CustomerService.prototype.CreateCustomer = function (model) {
        var url = "/api/v1/Customer/registration-web";
        var result = this.data.Post(url, model);
        return result;
    };
    CustomerService.prototype.resetCustomerBalance = function (id) {
        var url = "/api/v1/customer/reset-customer/" + id + "/balance";
        var result = this.data.Get(url);
        return result;
    };
    CustomerService.prototype.GetCustomer = function (id) {
        var url = "/api/v1/customer/" + id + "/item";
        var result = this.data.Get(url);
        return result;
    };
    CustomerService.prototype.UpdateCustomer = function (model) {
        var url = "/api/v1/customer/update";
        var result = this.data.Put(url, model);
        return result;
    };
    CustomerService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_data_service__WEBPACK_IMPORTED_MODULE_1__["DataService"], _storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"]])
    ], CustomerService);
    return CustomerService;
}());



/***/ }),

/***/ "../src/app/service/data.service.ts":
/*!******************************************!*\
  !*** ../src/app/service/data.service.ts ***!
  \******************************************/
/*! exports provided: DataService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DataService", function() { return DataService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "../node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _storage_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ "../node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs/operators */ "../node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_8___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_8__);
/* harmony import */ var _shared_Constants__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../shared/Constants */ "../src/app/shared/Constants.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};










var DataService = /** @class */ (function () {
    // private baseUrl: string = 'http:\\localhost:6787\';
    // private baseUrl1: string = 'http:\\67.144.45.89:71\';
    function DataService(http, storage, router, toastr, spinnerService) {
        this.http = http;
        this.storage = storage;
        this.router = router;
        this.toastr = toastr;
        this.spinnerService = spinnerService;
        this.users = [];
        this.token = new _shared_model__WEBPACK_IMPORTED_MODULE_2__["Token"]();
    }
    // public httpOptions = {
    //   headers: new HttpHeaders({
    //     'Content-Type': 'application/json',
    //     'Authorization': `Bearer ${this.storage.Token.token}`
    //   })
    // };
    DataService.prototype.GetToken = function () {
        var token = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_9__["Constants"].OAuthTokenKey);
        var _toks = JSON.parse(token);
        return _toks;
    };
    DataService.prototype.GetRole = function () {
        var user = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_9__["Constants"].UserKey);
        var _user = JSON.parse(user);
        return _user.Role;
    };
    DataService.prototype.Get = function (url, data) {
        var _this = this;
        var token = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_9__["Constants"].OAuthTokenKey);
        var _toks = JSON.parse(token);
        var httpOption = { headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]({ 'Authorization': "Bearer " + _toks }) };
        this.spinnerService.show();
        return this.http.get(url, httpOption).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["tap"])(// Log the result or error
        // tslint:disable-next-line:no-shadowed-variable
        function (// Log the result or error
        data) {
            _this.log(url, data);
            _this.spinnerService.hide();
        }, function (error) {
            _this.logError(url, error);
            _this.spinnerService.hide();
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["catchError"])(this.handleError));
    };
    DataService.prototype.Put = function (url, data) {
        var _this = this;
        var token = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_9__["Constants"].OAuthTokenKey);
        var _toks = JSON.parse(token);
        var httpOption = { headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]({ 'Authorization': 'Bearer ' + _toks }) };
        this.spinnerService.show();
        return this.http.put(url, data, httpOption).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["tap"])(// Log the result or error
        // tslint:disable-next-line:no-shadowed-variable
        function (// Log the result or error
        data) {
            _this.log(url, data);
            _this.spinnerService.hide();
        }, function (error) {
            _this.logError(url, error);
            _this.spinnerService.hide();
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["catchError"])(this.handleError));
    };
    DataService.prototype.Delete = function (url, data) {
        var _this = this;
        var token = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_9__["Constants"].OAuthTokenKey);
        var _toks = JSON.parse(token);
        var httpOption = { headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]({ 'Authorization': 'Bearer ' + _toks }) };
        this.spinnerService.show();
        return this.http.delete(url, httpOption).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["tap"])(// Log the result or error
        // tslint:disable-next-line:no-shadowed-variable
        function (// Log the result or error
        data) {
            _this.log(url, data);
            _this.spinnerService.hide();
        }, function (error) {
            _this.logError(url, error);
            _this.spinnerService.hide();
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["catchError"])(this.handleError));
    };
    DataService.prototype.GetWithOutToken = function (url, data) {
        var _this = this;
        this.spinnerService.show();
        return this.http.get(url).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["tap"])(// Log the result or error
        // tslint:disable-next-line:no-shadowed-variable
        function (// Log the result or error
        data) {
            _this.log(url, data);
            _this.spinnerService.hide();
        }, function (error) {
            _this.logError(url, error);
            _this.spinnerService.hide();
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["catchError"])(this.handleError));
    };
    DataService.prototype.PostWithOutToken = function (url, data) {
        var _this = this;
        this.spinnerService.show();
        return this.http.post(url, data).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["tap"])(// Log the result or error
        // tslint:disable-next-line:no-shadowed-variable
        function (// Log the result or error
        data) {
            _this.log(url, data);
            _this.spinnerService.hide();
        }, function (error) {
            _this.logError(url, error);
            _this.spinnerService.hide();
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["catchError"])(this.handleError));
    };
    DataService.prototype.PostBlob = function (url, blob) {
        var _this = this;
        this.spinnerService.show();
        return this.http.post(url, { responseType: 'blob' }, blob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["tap"])(// Log the result or error
        function (// Log the result or error
        data) {
            _this.log(url, data);
            _this.spinnerService.hide();
        }, function (error) {
            _this.logError(url, error);
            _this.spinnerService.hide();
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["catchError"])(this.handleError));
    };
    DataService.prototype.Post = function (url, data) {
        var _this = this;
        var token = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_9__["Constants"].OAuthTokenKey);
        var _toks = JSON.parse(token);
        // console.log(_toks);
        var httpOption = { headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]({ 'Authorization': 'Bearer ' + _toks }) };
        this.spinnerService.show();
        return this.http.post(url, data, httpOption).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["tap"])(// Log the result or error
        // tslint:disable-next-line:no-shadowed-variable
        function (// Log the result or error
        data) {
            _this.log(url, data);
            _this.spinnerService.hide();
        }, function (error) {
            _this.logError(url, error);
            _this.spinnerService.hide();
        }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_6__["catchError"])(this.handleError));
    };
    DataService.prototype.handleError = function (error) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            // this.toastr.error('An error occurred:', error.error.message, 'Error');
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            // this.toastr.error(`Backend returned code ${error.status}, ` +
            //  `body was: ${error.error}`, 'Error');
            return rxjs__WEBPACK_IMPORTED_MODULE_5__["Observable"].throw(error.message);
        }
        // return an ErrorObservable with a user-facing error message
        // this.toastr.error('Something bad happened; please try again later.', 'Error');
        return;
        // return new ErrorObservable(
        //  'Something bad happened; please try again later.');
    };
    DataService.prototype._handleError = function (err) {
        var errorMsg = err.message || 'Unable to retrieve data';
        return rxjs__WEBPACK_IMPORTED_MODULE_5__["Observable"].throw(errorMsg);
    };
    DataService.prototype.log = function (url, data) {
        // console.log(`Http operation was successfully called ${url}`);
    };
    DataService.prototype.logError = function (url, data) {
        console.log("Http operation failed " + url);
    };
    DataService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"], _storage_service__WEBPACK_IMPORTED_MODULE_3__["StorageService"], _angular_router__WEBPACK_IMPORTED_MODULE_4__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_7__["ToastrService"], ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_8__["Ng4LoadingSpinnerService"]])
    ], DataService);
    return DataService;
}());



/***/ }),

/***/ "../src/app/service/report.service.ts":
/*!********************************************!*\
  !*** ../src/app/service/report.service.ts ***!
  \********************************************/
/*! exports provided: ReportService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ReportService", function() { return ReportService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _data_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./data.service */ "../src/app/service/data.service.ts");
/* harmony import */ var _storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ReportService = /** @class */ (function () {
    function ReportService(data, storage) {
        this.data = data;
        this.storage = storage;
    }
    // user registration
    ReportService.prototype.GetDashboard = function () {
        var url = "/api/v1/report/dashboard";
        var r = this.data.Get(url);
        return r;
    };
    ReportService.prototype.GetSmsNotification = function () {
        var url = "/api/v1/settlement/sms-notify";
        var r = this.data.Get(url);
        return r;
    };
    ReportService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: "root"
        }),
        __metadata("design:paramtypes", [_data_service__WEBPACK_IMPORTED_MODULE_1__["DataService"], _storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"]])
    ], ReportService);
    return ReportService;
}());



/***/ }),

/***/ "../src/app/service/storage.service.ts":
/*!*********************************************!*\
  !*** ../src/app/service/storage.service.ts ***!
  \*********************************************/
/*! exports provided: StorageService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StorageService", function() { return StorageService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_Constants__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/Constants */ "../src/app/shared/Constants.ts");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var StorageService = /** @class */ (function () {
    function StorageService() {
        this.user = new _shared_model__WEBPACK_IMPORTED_MODULE_2__["User"]();
        this.token = new _shared_model__WEBPACK_IMPORTED_MODULE_2__["Token"]();
    }
    StorageService.prototype.GetToken = function () {
        var token = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_1__["Constants"].OAuthTokenKey);
        var _toks = JSON.parse(token);
        return _toks;
    };
    StorageService.prototype.GetUserInfo = function () {
        var _user = localStorage.getItem(_shared_Constants__WEBPACK_IMPORTED_MODULE_1__["Constants"].UserKey);
        this.user = JSON.parse(_user);
        return this.user;
    };
    StorageService.prototype.ngOnInit = function () { };
    Object.defineProperty(StorageService.prototype, "User", {
        get: function () {
            if (!this.user) {
                this.user = this.Get(_shared_Constants__WEBPACK_IMPORTED_MODULE_1__["Constants"].UserKey);
            }
            return this.user;
        },
        set: function (user) {
            this.user = user;
            this.Store(_shared_Constants__WEBPACK_IMPORTED_MODULE_1__["Constants"].UserKey, user);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(StorageService.prototype, "Token", {
        get: function () {
            if (!this.token) {
                this.token = this.Get(_shared_Constants__WEBPACK_IMPORTED_MODULE_1__["Constants"].OAuthTokenKey);
            }
            return this.token;
        },
        set: function (token) {
            this.Store(_shared_Constants__WEBPACK_IMPORTED_MODULE_1__["Constants"].OAuthTokenKey, token);
        },
        enumerable: true,
        configurable: true
    });
    // Local Storage Methods
    StorageService.prototype.Store = function (key, value) {
        return localStorage.setItem(key, JSON.stringify(value));
    };
    StorageService.prototype.Remove = function (key) {
        localStorage.removeItem(key);
    };
    StorageService.prototype.Get = function (key) {
        return JSON.parse(localStorage.getItem(key));
    };
    StorageService.prototype.Clear = function () {
        localStorage.clear();
    };
    StorageService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: "root"
        }),
        __metadata("design:paramtypes", [])
    ], StorageService);
    return StorageService;
}());



/***/ }),

/***/ "../src/app/service/transaction.service.ts":
/*!*************************************************!*\
  !*** ../src/app/service/transaction.service.ts ***!
  \*************************************************/
/*! exports provided: TransactionService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TransactionService", function() { return TransactionService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _data_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./data.service */ "../src/app/service/data.service.ts");
/* harmony import */ var _storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TransactionService = /** @class */ (function () {
    function TransactionService(data, storage) {
        this.data = data;
        this.storage = storage;
    }
    TransactionService.prototype.getTransactionSearch = function (model) {
        var url = "/api/v1/transaction/records";
        var result = this.data.Post(url, model);
        return result;
    };
    TransactionService.prototype.getTransaction = function (pageIndex, pageSize) {
        var url = "/api/v1/transaction/" + pageIndex + "/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    TransactionService.prototype.getTransactionLog = function (pageIndex, pageSize) {
        var url = "/api/v1/transaction/" + pageIndex + "/logs/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    TransactionService.prototype.getCreditTransaction = function (pageIndex, pageSize) {
        var url = "/api/v1/transaction/" + pageIndex + "/credit/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    TransactionService.prototype.getDebitTransaction = function (pageIndex, pageSize) {
        var url = "/api/v1/transaction/" + pageIndex + "/debit/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    TransactionService.prototype.getCustomerNameByCode = function (search) {
        var url = "/api/v1/customer/" + search;
        var result = this.data.Get(url);
        return result;
    };
    TransactionService.prototype.PostTransactionLog = function (model) {
        var url = "/api/v1/transaction/log";
        var result = this.data.Post(url, model);
        return result;
    };
    TransactionService.prototype.ApproveTransaction = function (id) {
        var url = "/api/v1/transaction/approval/" + id;
        var result = this.data.Get(url);
        return result;
    };
    TransactionService.prototype.DelineTransaction = function (id) {
        var url = "/api/v1/transaction/decline/" + id;
        var result = this.data.Get(url);
        return result;
    };
    TransactionService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_data_service__WEBPACK_IMPORTED_MODULE_1__["DataService"], _storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"]])
    ], TransactionService);
    return TransactionService;
}());



/***/ }),

/***/ "../src/app/service/withdrawal.service.ts":
/*!************************************************!*\
  !*** ../src/app/service/withdrawal.service.ts ***!
  \************************************************/
/*! exports provided: WithdrawalService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WithdrawalService", function() { return WithdrawalService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _data_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./data.service */ "../src/app/service/data.service.ts");
/* harmony import */ var _storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var WithdrawalService = /** @class */ (function () {
    function WithdrawalService(data, storage) {
        this.data = data;
        this.storage = storage;
    }
    WithdrawalService.prototype.getWithdrawalSearch = function (model) {
        var url = "/api/v1/withdrawal/records";
        var result = this.data.Post(url, model);
        return result;
    };
    // Get withdrawal
    WithdrawalService.prototype.getWithdrawal = function (pageIndex, pageSize) {
        var url = "/api/v1/withdrawal/" + pageIndex + "/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    WithdrawalService.prototype.getApproveWithdrawal = function (pageIndex, pageSize) {
        var url = "/api/v1/withdrawal/" + pageIndex + "/approved/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    WithdrawalService.prototype.getPaidWithdrawal = function (pageIndex, pageSize) {
        var url = "/api/v1/withdrawal/" + pageIndex + "/paid/" + pageSize;
        var result = this.data.Get(url);
        return result;
    };
    WithdrawalService.prototype.getCustomerNameByCode = function (search) {
        var url = "/api/v1/customer/" + search;
        var result = this.data.Get(url);
        return result;
    };
    WithdrawalService.prototype.PostWithdrawal = function (model) {
        var url = "/api/v1/withdrawal/web";
        var result = this.data.Post(url, model);
        return result;
    };
    WithdrawalService.prototype.WithdrawalApproval = function (model) {
        var url = "/api/v1/withdrawal/approval/admin";
        var result = this.data.Post(url, model);
        return result;
    };
    WithdrawalService.prototype.WithdrawalDecline = function (id) {
        var url = "/api/v1/withdrawal/decline/" + id;
        var result = this.data.Get(url);
        return result;
    };
    WithdrawalService.prototype.GetSystemAdmin = function () {
        var url = "/api/v1/account/agent-names";
        var result = this.data.Get(url);
        return result;
    };
    WithdrawalService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_data_service__WEBPACK_IMPORTED_MODULE_1__["DataService"], _storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"]])
    ], WithdrawalService);
    return WithdrawalService;
}());



/***/ }),

/***/ "../src/app/shared/Constants.ts":
/*!**************************************!*\
  !*** ../src/app/shared/Constants.ts ***!
  \**************************************/
/*! exports provided: Constants */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Constants", function() { return Constants; });
var Constants;
(function (Constants) {
    // constant for fetching authorization from local browser keystore
    Constants.OAuthTokenKey = "payajotok";
    Constants.UserKey = "payajouser";
    Constants.Web_Address = "";
    Constants.LoginUrl = "/account/index";
    Constants.Url = document.location.protocol +
        "//" +
        document.location.hostname +
        ":" +
        document.location.port;
    Constants.Roles = {
        Administrator: "Administrator",
        User: "User"
    };
    Constants.ResponseCode = {
        Success: "200"
    };
    Constants.AppMonths = {
        January: "January",
        February: "February",
        March: "March",
        April: "April",
        May: "May",
        June: "June",
        July: "July",
        August: "August",
        September: "September",
        October: "October",
        November: "November",
        December: "December"
    };
    Constants.DATE_FMT = "dd/MMM/yyyy";
    Constants.DATE_TIME_FMT = Constants.DATE_FMT + " hh:mm:ss";
})(Constants || (Constants = {}));


/***/ }),

/***/ "../src/app/shared/model.ts":
/*!**********************************!*\
  !*** ../src/app/shared/model.ts ***!
  \**********************************/
/*! exports provided: Model, RecordStatus, ResponseResource, Token, Operation, Alert, AlertType, UserLogin, SmsNotificationModel, NotifyModel, NotificationSystem, NotificationType, DashboardModel, TransactionResponse, AgentModel, TransactionLogger, WithdrawalLogger, Merchant, Customer, RegistrationChannel, SearchModel, AgentUserAdmin, WithdrawalResponse, WithdrawApprovalModel, WithdrawalStatus, AdminUser, User, PasswordChange, UserResource, UserRole, Role, Dashboard */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Model", function() { return Model; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RecordStatus", function() { return RecordStatus; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ResponseResource", function() { return ResponseResource; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Token", function() { return Token; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Operation", function() { return Operation; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Alert", function() { return Alert; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AlertType", function() { return AlertType; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserLogin", function() { return UserLogin; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SmsNotificationModel", function() { return SmsNotificationModel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NotifyModel", function() { return NotifyModel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NotificationSystem", function() { return NotificationSystem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NotificationType", function() { return NotificationType; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DashboardModel", function() { return DashboardModel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TransactionResponse", function() { return TransactionResponse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AgentModel", function() { return AgentModel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TransactionLogger", function() { return TransactionLogger; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WithdrawalLogger", function() { return WithdrawalLogger; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Merchant", function() { return Merchant; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Customer", function() { return Customer; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RegistrationChannel", function() { return RegistrationChannel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SearchModel", function() { return SearchModel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AgentUserAdmin", function() { return AgentUserAdmin; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WithdrawalResponse", function() { return WithdrawalResponse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WithdrawApprovalModel", function() { return WithdrawApprovalModel; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WithdrawalStatus", function() { return WithdrawalStatus; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdminUser", function() { return AdminUser; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "User", function() { return User; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PasswordChange", function() { return PasswordChange; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserResource", function() { return UserResource; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserRole", function() { return UserRole; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Role", function() { return Role; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Dashboard", function() { return Dashboard; });
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Model = /** @class */ (function () {
    function Model() {
    }
    return Model;
}());

var RecordStatus;
(function (RecordStatus) {
    RecordStatus[RecordStatus["Active"] = 0] = "Active";
    RecordStatus[RecordStatus["Deleted"] = 1] = "Deleted";
    RecordStatus[RecordStatus["Deactived"] = 2] = "Deactived";
    RecordStatus[RecordStatus["Locked"] = 3] = "Locked";
    RecordStatus[RecordStatus["Blocked"] = 4] = "Blocked";
    RecordStatus[RecordStatus["Processing"] = 5] = "Processing";
    RecordStatus[RecordStatus["Pending"] = 6] = "Pending";
    RecordStatus[RecordStatus["Successful"] = 7] = "Successful";
    RecordStatus[RecordStatus["Failed"] = 8] = "Failed";
})(RecordStatus || (RecordStatus = {}));
var ResponseResource = /** @class */ (function () {
    function ResponseResource() {
        this.Errors = new Array();
    }
    return ResponseResource;
}());

var Token = /** @class */ (function () {
    function Token() {
    }
    Object.defineProperty(Token.prototype, "loginRequired", {
        get: function () {
            return this.token.length === 0 || this.expiration > new Date();
        },
        enumerable: true,
        configurable: true
    });
    return Token;
}());

var Operation = /** @class */ (function () {
    function Operation() {
    }
    return Operation;
}());

var Alert = /** @class */ (function () {
    function Alert() {
    }
    return Alert;
}());

var AlertType;
(function (AlertType) {
    AlertType[AlertType["Success"] = 0] = "Success";
    AlertType[AlertType["Error"] = 1] = "Error";
    AlertType[AlertType["Info"] = 2] = "Info";
    AlertType[AlertType["Warning"] = 3] = "Warning";
})(AlertType || (AlertType = {}));
var UserLogin = /** @class */ (function () {
    function UserLogin() {
    }
    return UserLogin;
}());

var SmsNotificationModel = /** @class */ (function () {
    function SmsNotificationModel() {
    }
    return SmsNotificationModel;
}());

var NotifyModel = /** @class */ (function () {
    function NotifyModel() {
    }
    return NotifyModel;
}());

var NotificationSystem;
(function (NotificationSystem) {
    NotificationSystem[NotificationSystem["UserAccount"] = 0] = "UserAccount";
    NotificationSystem[NotificationSystem["Transacition"] = 1] = "Transacition";
    NotificationSystem[NotificationSystem["CollectionType"] = 2] = "CollectionType";
    NotificationSystem[NotificationSystem["Notification"] = 3] = "Notification";
    NotificationSystem[NotificationSystem["Withdrawal"] = 4] = "Withdrawal";
})(NotificationSystem || (NotificationSystem = {}));
var NotificationType;
(function (NotificationType) {
    NotificationType[NotificationType["Sms"] = 0] = "Sms";
    NotificationType[NotificationType["Email"] = 1] = "Email";
})(NotificationType || (NotificationType = {}));
var DashboardModel = /** @class */ (function () {
    function DashboardModel() {
    }
    return DashboardModel;
}());

var TransactionResponse = /** @class */ (function (_super) {
    __extends(TransactionResponse, _super);
    function TransactionResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Object.defineProperty(TransactionResponse.prototype, "CustomerCode", {
        get: function () {
            return this._CustomerCode;
        },
        set: function (value) {
            this._CustomerCode = value;
        },
        enumerable: true,
        configurable: true
    });
    return TransactionResponse;
}(Model));

var AgentModel = /** @class */ (function () {
    function AgentModel() {
    }
    return AgentModel;
}());

var TransactionLogger = /** @class */ (function () {
    function TransactionLogger() {
    }
    return TransactionLogger;
}());

var WithdrawalLogger = /** @class */ (function () {
    function WithdrawalLogger() {
    }
    return WithdrawalLogger;
}());

var Merchant = /** @class */ (function () {
    function Merchant() {
    }
    return Merchant;
}());

var Customer = /** @class */ (function (_super) {
    __extends(Customer, _super);
    function Customer() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Customer;
}(Model));

var RegistrationChannel;
(function (RegistrationChannel) {
    RegistrationChannel[RegistrationChannel["IsMobile"] = 0] = "IsMobile";
    RegistrationChannel[RegistrationChannel["IsWeb"] = 1] = "IsWeb";
})(RegistrationChannel || (RegistrationChannel = {}));
var SearchModel = /** @class */ (function () {
    function SearchModel() {
    }
    return SearchModel;
}());

var AgentUserAdmin = /** @class */ (function () {
    function AgentUserAdmin() {
    }
    return AgentUserAdmin;
}());

var WithdrawalResponse = /** @class */ (function (_super) {
    __extends(WithdrawalResponse, _super);
    function WithdrawalResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return WithdrawalResponse;
}(Model));

var WithdrawApprovalModel = /** @class */ (function () {
    function WithdrawApprovalModel() {
    }
    return WithdrawApprovalModel;
}());

var WithdrawalStatus = /** @class */ (function () {
    function WithdrawalStatus() {
    }
    return WithdrawalStatus;
}());

var AdminUser = /** @class */ (function () {
    function AdminUser() {
    }
    return AdminUser;
}());

var User = /** @class */ (function () {
    function User() {
    }
    return User;
}());

var PasswordChange = /** @class */ (function () {
    function PasswordChange() {
    }
    return PasswordChange;
}());

var UserResource = /** @class */ (function () {
    function UserResource() {
    }
    return UserResource;
}());

var RegChannel;
(function (RegChannel) {
    RegChannel[RegChannel["IsMobile"] = 1] = "IsMobile";
    RegChannel[RegChannel["IsWeb"] = 2] = "IsWeb";
})(RegChannel || (RegChannel = {}));
var UserStatus;
(function (UserStatus) {
    UserStatus[UserStatus["Pending"] = 0] = "Pending";
    UserStatus[UserStatus["Verified"] = 1] = "Verified";
    UserStatus[UserStatus["Blocked"] = 2] = "Blocked";
})(UserStatus || (UserStatus = {}));
var UserRole = /** @class */ (function () {
    function UserRole() {
    }
    return UserRole;
}());

var Role = /** @class */ (function () {
    function Role() {
    }
    return Role;
}());

var Dashboard = /** @class */ (function () {
    function Dashboard() {
    }
    return Dashboard;
}());



/***/ }),

/***/ "../src/app/shared/navigation/navigation.component.html":
/*!**************************************************************!*\
  !*** ../src/app/shared/navigation/navigation.component.html ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"sidebar sidebar-custom\" data-color=\"#9a7f37\">\n  <div class=\"logo\">\n    <a href=\"javascript:;\" class=\"simple-text logo-mini\">\n      <img src=\"../assets/img/eureka-logo.jpg\" class=\"img-responsive\" alt=\"Image\">\n    </a>\n    <a href=\"javascript:;\" class=\"simple-text logo-normal\">\n      PayAjo\n    </a>\n  </div>\n  <div class=\"sidebar-wrapper ps-container ps-theme-default ps-active-y\" data-ps-id=\"4cf8b97b-28e4-7c84-16c4-f04b08b36ef8\">\n    <ul class=\"nav nav-custom\">\n      <li class=\"active\">\n        <a href=\"javascript:;\" [routerLink]=\"['/dashboard']\">\n          <i class=\"now-ui-icons design_app\"></i>\n          <p>Dashboard</p>\n        </a>\n      </li>\n      <li>\n        <a data-toggle=\"collapse\" href=\"#customer\" aria-expanded=\"false\" class=\"collapsed\">\n          <i class=\"now-ui-icons education_atom\"></i>\n          <p>Customers\n            <b class=\"caret\"></b>\n          </p>\n        </a>\n\n        <div class=\"collapse\" id=\"customer\">\n          <ul class=\"nav\">\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/customer']\">\n                <span class=\"sidebar-mini-icon\">C</span>\n                <span class=\"sidebar-normal\">All Customers</span>\n              </a>\n            </li>\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/active-customer']\">\n                <span class=\"sidebar-mini-icon\">A</span>\n                <span class=\"sidebar-normal\">Active Customers</span>\n              </a>\n            </li>\n            <!-- <li>\n                          <a href=\"javascript:;\" [routerLink]=\"['/inactive-customer']\">\n                              <span class=\"sidebar-mini-icon\">I</span>\n                              <span class=\"sidebar-normal\">InActve Customers</span>\n                          </a>\n                      </li> -->\n          </ul>\n        </div>\n      </li>\n      <li>\n        <a data-toggle=\"collapse\" href=\"#transactions\" class=\"collapsed\" aria-expanded=\"false\">\n          <i class=\"now-ui-icons files_single-copy-04\"></i>\n          <p>Transactions\n            <b class=\"caret\"></b>\n          </p>\n        </a>\n\n        <div class=\"collapse\" id=\"transactions\">\n          <ul class=\"nav\">\n\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/transactionlog']\">\n                <span class=\"sidebar-mini-icon\">TL</span>\n                <span class=\"sidebar-normal\">Transaction Log</span>\n              </a>\n            </li>\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/transaction']\">\n                <span class=\"sidebar-mini-icon\">T</span>\n                <span class=\"sidebar-normal\">All Transactions</span>\n              </a>\n            </li>\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/credittransaction']\">\n                <span class=\"sidebar-mini-icon\">C</span>\n                <span class=\"sidebar-normal\">Credit Transactions</span>\n              </a>\n            </li>\n\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/debittransaction']\">\n                <span class=\"sidebar-mini-icon\">D</span>\n                <span class=\"sidebar-normal\">Debit Transaction</span>\n              </a>\n            </li>\n          </ul>\n        </div>\n      </li>\n\n\n      <li>\n        <a data-toggle=\"collapse\" href=\"#withdrawal\" class=\"collapsed\" aria-expanded=\"false\">\n          <i class=\"now-ui-icons design_bullet-list-67\"></i>\n          <p>Withdrawal\n            <b class=\"caret\"></b>\n          </p>\n        </a>\n\n        <div class=\"collapse\" id=\"withdrawal\">\n          <ul class=\"nav\">\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/withdrawal']\">\n                <span class=\"sidebar-mini-icon\">W</span>\n                <span class=\"sidebar-normal\">All Withdrawal</span>\n              </a>\n            </li>\n            <!-- <li>\n                          <a href=\"javascript:;\" [routerLink]=\"['/approvedwithdrawal']\" >\n                              <span class=\"sidebar-mini-icon\">A</span>\n                              <span class=\"sidebar-normal\">Approved Withdrawal</span>\n                          </a>\n                      </li> -->\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/paidwithdrawal']\">\n                <span class=\"sidebar-mini-icon\">P</span>\n                <span class=\"sidebar-normal\">Paid Withdrawal</span>\n              </a>\n            </li>\n          </ul>\n        </div>\n      </li>\n      <li>\n        <a data-toggle=\"collapse\" href=\"#useraccount\" class=\"collapsed\" aria-expanded=\"false\">\n          <i class=\"now-ui-icons business_chart-pie-36\"></i>\n          <p>User Account\n            <b class=\"caret\"></b>\n          </p>\n        </a>\n        <div class=\"collapse\" id=\"useraccount\">\n          <ul class=\"nav\">\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/users']\">\n                <span class=\"sidebar-mini-icon\">U</span>\n                <span class=\"sidebar-normal\">All User </span>\n              </a>\n            </li>\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/profile']\">\n                <span class=\"sidebar-mini-icon\">P</span>\n                <span class=\"sidebar-normal\">User Profile</span>\n              </a>\n            </li>\n            <li *ngIf=\"roleName == 'Merchant Admin'\">\n              <a href=\"javascript:;\" [routerLink]=\"['/agent']\">\n                <span class=\"sidebar-mini-icon\">A</span>\n                <span class=\"sidebar-normal\">All Agent</span>\n              </a>\n            </li>\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/change-password']\">\n                <span class=\"sidebar-mini-icon\">C</span>\n                <span class=\"sidebar-normal\">Change Password</span>\n              </a>\n            </li>\n          </ul>\n        </div>\n      </li>\n      <li *ngIf=\"roleName == 'Merchant Admin'\">\n        <a data-toggle=\"collapse\" href=\"#accountcharges\" class=\"collapsed\" aria-expanded=\"false\">\n          <i class=\"fa fa-credit-card\"></i>\n          <p>Account Charges\n            <b class=\"caret\"></b>\n          </p>\n\n        </a>\n        <div class=\"collapse\" id=\"accountcharges\">\n          <ul class=\"nav\">\n            <li>\n              <a href=\"javascript:;\" [routerLink]=\"['/smsdebit']\">\n                <span class=\"sidebar-mini-icon\">SD</span>\n                <span class=\"sidebar-normal\">SMS Debit</span>\n              </a>\n            </li>\n            <li *ngIf=\"roleName == 'Merchant Admin1'\">\n              <a href=\"javascript:;\" [routerLink]=\"['/techdebit']\">\n                <span class=\"sidebar-mini-icon\">TD</span>\n                <span class=\"sidebar-normal\">Tech Fee Debit</span>\n              </a>\n            </li>\n            <li *ngIf=\"roleName == 'Merchant Admin1'\">\n              <a href=\"javascript:;\" [routerLink]=\"['/smspayment']\">\n                <span class=\"sidebar-mini-icon\">SP</span>\n                <span class=\"sidebar-normal\">Sms Payment</span>\n              </a>\n            </li>\n            <li *ngIf=\"roleName == 'Merchant Admin1'\">\n              <a href=\"javascript:;\" [routerLink]=\"['/techpayment']\">\n                <span class=\"sidebar-mini-icon\">TF</span>\n                <span class=\"sidebar-normal\">tech Fee Payment</span>\n              </a>\n            </li>\n          </ul>\n        </div>\n      </li>\n    </ul>\n    <div class=\"ps-scrollbar-x-rail\" style=\"left: 0px; bottom: 0px;\">\n      <div class=\"ps-scrollbar-x\" tabindex=\"0\" style=\"left: 0px; width: 0px;\"></div>\n    </div>\n    <div class=\"ps-scrollbar-y-rail\" style=\"top: 0px; height: 613px; right: 0px;\">\n      <div class=\"ps-scrollbar-y\" tabindex=\"0\" style=\"top: 0px; height: 488px;\"></div>\n    </div>\n  </div>\n</div>\n"

/***/ }),

/***/ "../src/app/shared/navigation/navigation.component.ts":
/*!************************************************************!*\
  !*** ../src/app/shared/navigation/navigation.component.ts ***!
  \************************************************************/
/*! exports provided: NavigationComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavigationComponent", function() { return NavigationComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../service/storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var NavigationComponent = /** @class */ (function () {
    function NavigationComponent(router, toastr, storage, spinnerService) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.roleName = " ";
    }
    NavigationComponent.prototype.ngOnInit = function () {
        try {
            this.roleName = this.storage.GetUserInfo().Role;
            if (this.roleName !== " ") {
                this.merchantName = this.storage.GetUserInfo().MerchantName;
                this.name =
                    this.storage.GetUserInfo().LastName +
                        " " +
                        this.storage.GetUserInfo().FirstName;
                this.lastloginDate = this.storage.GetUserInfo().LastLoginDate;
            }
            else {
                this.roleName = " ";
            }
        }
        catch (ex) { }
        // ../assets/js/plugins/perfect-scrollbar.jquery.min.js
    };
    NavigationComponent.prototype.logout = function () {
        var protocol = document.location.protocol;
        var hostname = document.location.hostname;
        var port = document.location.port;
        try {
            this.storage.Clear();
            document.location.href = protocol + "//" + hostname + ":" + port + "/#/login";
        }
        catch (e) {
            console.log(e);
            document.location.href = protocol + "//" + hostname + ":" + port + "/#/login";
        }
    };
    NavigationComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-navigation",
            template: __webpack_require__(/*! ./navigation.component.html */ "../src/app/shared/navigation/navigation.component.html")
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_3__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_4__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2__["Ng4LoadingSpinnerService"]])
    ], NavigationComponent);
    return NavigationComponent;
}());



/***/ }),

/***/ "../src/app/shared/navigation/topnav.component.html":
/*!**********************************************************!*\
  !*** ../src/app/shared/navigation/topnav.component.html ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<!-- Navbar -->\n<nav class=\"navbar navbar-expand-lg navbar-absolute bg-primary fixed-top navbar-transparent\">\n  <div class=\"container-fluid\">\n    <div class=\"navbar-wrapper\">\n      <div class=\"navbar-toggle toggled\">\n        <button type=\"button\" class=\"navbar-toggler\">\n          <span class=\"navbar-toggler-bar bar1\"></span>\n          <span class=\"navbar-toggler-bar bar2\"></span>\n          <span class=\"navbar-toggler-bar bar3\"></span>\n        </button>\n      </div>\n      <!-- BreadCrumb -->\n      <ul class=\"breadcrumb breadcrumb-custom\">\n        <li class=\"breadcrumb-item\">\n          <a href=\"javascript:;\" class=\"breadcrumb-active\">Dashboard</a>\n        </li>\n      </ul>\n    </div>\n    <button class=\"navbar-toggler collapsed\" type=\"button\" data-toggle=\"collapse\" data-target=\"#navigation\"\n      aria-controls=\"navigation-index\" aria-expanded=\"false\" aria-label=\"Toggle navigation\">\n      <span class=\"navbar-toggler-bar navbar-kebab\"></span>\n      <span class=\"navbar-toggler-bar navbar-kebab\"></span>\n      <span class=\"navbar-toggler-bar navbar-kebab\"></span>\n    </button>\n    <div class=\"navbar-collapse justify-content-end collapse\" id=\"navigation\" style=\"\">\n      <ul class=\"navbar-nav\">\n        <li> Merchant: <span style='color: orange'> {{merchantName | uppercase }} </span>\n          &nbsp;Name: <span style='color: orange'> {{name | uppercase }}</span>\n          &nbsp; Last Login date: <span style='color: orange'>{{\n            lastloginDate | date }}</span> &nbsp;\n        </li>\n      </ul>\n      <form>\n        <div class=\"input-group no-border\">\n          <input type=\"text\" value=\"\" class=\"form-control\" placeholder=\"Search...\">\n          <span class=\"input-group-addon\">\n            <i class=\"now-ui-icons ui-1_zoom-bold\"></i>\n          </span>\n        </div>\n      </form>\n      <ul class=\"navbar-nav\">\n        <li class=\"nav-item dropdown\">\n\n          <a class=\"nav-link dropdown-toggle\" href=\"javascript:;\" id=\"navbarDropdownMenuLink\" data-toggle=\"dropdown\"\n            aria-haspopup=\"true\" aria-expanded=\"false\">\n            <i class=\"now-ui-icons users_single-02\"></i>\n            <p>\n              <span class=\"d-lg-none d-md-block\">\n\n              </span>\n            </p>\n          </a>\n          <div class=\"dropdown-menu dropdown-menu-right\" aria-labelledby=\"navbarDropdownMenuLink\">\n            <a class=\"dropdown-item\" href=\"javascript:;\" [routerLink]=\"['/profile']\">Profile</a>\n            <a class=\"dropdown-item\" href=\"javascript:;\" (click)=\"logout()\">Sign out</a>\n          </div>\n        </li>\n      </ul>\n    </div>\n  </div>\n</nav>\n<!-- End Navbar -->\n"

/***/ }),

/***/ "../src/app/shared/navigation/topnav.component.ts":
/*!********************************************************!*\
  !*** ../src/app/shared/navigation/topnav.component.ts ***!
  \********************************************************/
/*! exports provided: TopNavComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TopNavComponent", function() { return TopNavComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../service/storage.service */ "../src/app/service/storage.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var TopNavComponent = /** @class */ (function () {
    function TopNavComponent(router, toastr, storage, spinnerService) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.roleName = " ";
    }
    TopNavComponent.prototype.ngOnInit = function () {
        try {
            this.roleName = this.storage.GetUserInfo().Role;
            this.merchantName = this.storage.GetUserInfo().MerchantName;
            this.name =
                this.storage.GetUserInfo().LastName +
                    " " +
                    this.storage.GetUserInfo().FirstName;
            this.lastloginDate = this.storage.GetUserInfo().LastLoginDate;
        }
        catch (ex) {
            this.router.navigate(["/login"]);
        }
        // $.getScript('../assets/assets/js/core/jquery.min.js');
    };
    TopNavComponent.prototype.logout = function () {
        var protocol = document.location.protocol;
        var hostname = document.location.hostname;
        var port = document.location.port;
        try {
            this.storage.Clear();
            document.location.href = protocol + "//" + hostname + ":" + port + "/#/login";
        }
        catch (e) {
            console.log(e);
            document.location.href = protocol + "//" + hostname + ":" + port + "/#/login";
        }
    };
    TopNavComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-topnav",
            template: __webpack_require__(/*! ./topnav.component.html */ "../src/app/shared/navigation/topnav.component.html")
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_3__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_4__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_2__["Ng4LoadingSpinnerService"]])
    ], TopNavComponent);
    return TopNavComponent;
}());



/***/ }),

/***/ "../src/app/shared/sequencepage.ts":
/*!*****************************************!*\
  !*** ../src/app/shared/sequencepage.ts ***!
  \*****************************************/
/*! exports provided: SequencePage */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SequencePage", function() { return SequencePage; });
// Class that implements pagination
var SequencePage = /** @class */ (function () {
    function SequencePage(page, sequenceLength, pageSize, pageIndex) {
        this.Page = [];
        if (page === null || pageIndex < 0 || sequenceLength < 0) {
            throw new Error('invalid page');
        }
        this.PageIndex = pageIndex || 0;
        this.SequenceLength = sequenceLength;
        this.Page = page;
        this.PageSize = pageSize || page.length;
        this.PageCount = sequenceLength === 0 ? 0 :
            (Math.floor(this.SequenceLength / this.PageSize) + (this.SequenceLength % this.PageSize > 0 ? 1 : 0));
    }
    /// <summary>
    /// Returns an array containing page indexes for pages immediately adjecent to the current page.
    /// The span indicates how many pages indexes to each side of the current page should be returned
    /// </summary>
    /// <param name="span"></param>
    /// <returns></returns>
    SequencePage.prototype.AdjacentIndexes = function (span) {
        if (span < 0) {
            throw new Error('invalid span: ' + span);
        }
        var fullspan = (span * 2) + 1;
        var start = 0;
        var count = 0;
        if (fullspan >= this.PageCount) {
            count = this.PageCount;
        }
        else {
            start = this.PageIndex - span;
            count = fullspan;
            if (start < 0) {
                start = 0;
            }
            if ((this.PageIndex + span) >= this.PageCount) {
                start = this.PageCount - fullspan;
            }
        }
        var pages = [];
        for (var indx = 0; indx < count; indx++) {
            pages.push(indx + start);
        }
        return pages;
    };
    return SequencePage;
}());



/***/ }),

/***/ "../src/app/transaction/createtransaction.component.css":
/*!**************************************************************!*\
  !*** ../src/app/transaction/createtransaction.component.css ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "html {\r\n  line-height: 1.15; /* 1 */\r\n  -ms-text-size-adjust: 100%; /* 2 */\r\n  -webkit-text-size-adjust: 100%; /* 2 */\r\n}\r\n\r\n/* Sections\r\n ========================================================================== */\r\n\r\n/**\r\n* Remove the margin in all browsers (opinionated).\r\n*/\r\n\r\nbody {\r\n  margin: 0;\r\n}\r\n\r\n/**\r\n* Add the correct display in IE 9-.\r\n*/\r\n\r\narticle,\r\naside,\r\nfooter,\r\nheader,\r\nnav,\r\nsection {\r\n  display: block;\r\n}\r\n\r\n/**\r\n* Correct the font size and margin on `h1` elements within `section` and\r\n* `article` contexts in Chrome, Firefox, and Safari.\r\n*/\r\n\r\nh1 {\r\n  font-size: 2em;\r\n  margin: 0.67em 0;\r\n}\r\n\r\n/* Grouping content\r\n ========================================================================== */\r\n\r\n/**\r\n* Add the correct display in IE 9-.\r\n* 1. Add the correct display in IE.\r\n*/\r\n\r\nfigcaption,\r\nfigure,\r\nmain { /* 1 */\r\n  display: block;\r\n}\r\n\r\n/**\r\n* Add the correct margin in IE 8.\r\n*/\r\n\r\nfigure {\r\n  margin: 1em 40px;\r\n}\r\n\r\n/**\r\n* 1. Add the correct box sizing in Firefox.\r\n* 2. Show the overflow in Edge and IE.\r\n*/\r\n\r\nhr {\r\n  box-sizing: content-box; /* 1 */\r\n  height: 0; /* 1 */\r\n  overflow: visible; /* 2 */\r\n}\r\n\r\n/**\r\n* 1. Correct the inheritance and scaling of font size in all browsers.\r\n* 2. Correct the odd `em` font sizing in all browsers.\r\n*/\r\n\r\npre {\r\n  font-family: monospace, monospace; /* 1 */\r\n  font-size: 1em; /* 2 */\r\n}\r\n\r\n/* Text-level semantics\r\n ========================================================================== */\r\n\r\n/**\r\n* 1. Remove the gray background on active links in IE 10.\r\n* 2. Remove gaps in links underline in iOS 8+ and Safari 8+.\r\n*/\r\n\r\na {\r\n  background-color: transparent; /* 1 */\r\n  -webkit-text-decoration-skip: objects; /* 2 */\r\n}\r\n\r\n/**\r\n* 1. Remove the bottom border in Chrome 57- and Firefox 39-.\r\n* 2. Add the correct text decoration in Chrome, Edge, IE, Opera, and Safari.\r\n*/\r\n\r\nabbr[title] {\r\n  border-bottom: none; /* 1 */\r\n  text-decoration: underline; /* 2 */\r\n  -webkit-text-decoration: underline dotted;\r\n          text-decoration: underline dotted; /* 2 */\r\n}\r\n\r\n/**\r\n* Prevent the duplicate application of `bolder` by the next rule in Safari 6.\r\n*/\r\n\r\nb,\r\nstrong {\r\n  font-weight: inherit;\r\n}\r\n\r\n/**\r\n* Add the correct font weight in Chrome, Edge, and Safari.\r\n*/\r\n\r\nb,\r\nstrong {\r\n  font-weight: bolder;\r\n}\r\n\r\n/**\r\n* 1. Correct the inheritance and scaling of font size in all browsers.\r\n* 2. Correct the odd `em` font sizing in all browsers.\r\n*/\r\n\r\ncode,\r\nkbd,\r\nsamp {\r\n  font-family: monospace, monospace; /* 1 */\r\n  font-size: 1em; /* 2 */\r\n}\r\n\r\n/**\r\n* Add the correct font style in Android 4.3-.\r\n*/\r\n\r\ndfn {\r\n  font-style: italic;\r\n}\r\n\r\n/**\r\n* Add the correct background and color in IE 9-.\r\n*/\r\n\r\nmark {\r\n  background-color: #ff0;\r\n  color: #000;\r\n}\r\n\r\n/**\r\n* Add the correct font size in all browsers.\r\n*/\r\n\r\nsmall {\r\n  font-size: 80%;\r\n}\r\n\r\n/**\r\n* Prevent `sub` and `sup` elements from affecting the line height in\r\n* all browsers.\r\n*/\r\n\r\nsub,\r\nsup {\r\n  font-size: 75%;\r\n  line-height: 0;\r\n  position: relative;\r\n  vertical-align: baseline;\r\n}\r\n\r\nsub {\r\n  bottom: -0.25em;\r\n}\r\n\r\nsup {\r\n  top: -0.5em;\r\n}\r\n\r\n/* Embedded content\r\n ========================================================================== */\r\n\r\n/**\r\n* Add the correct display in IE 9-.\r\n*/\r\n\r\naudio,\r\nvideo {\r\n  display: inline-block;\r\n}\r\n\r\n/**\r\n* Add the correct display in iOS 4-7.\r\n*/\r\n\r\naudio:not([controls]) {\r\n  display: none;\r\n  height: 0;\r\n}\r\n\r\n/**\r\n* Remove the border on images inside links in IE 10-.\r\n*/\r\n\r\nimg {\r\n  border-style: none;\r\n}\r\n\r\n/**\r\n* Hide the overflow in IE.\r\n*/\r\n\r\nsvg:not(:root) {\r\n  overflow: hidden;\r\n}\r\n\r\n/* Forms\r\n ========================================================================== */\r\n\r\n/**\r\n* 1. Change the font styles in all browsers (opinionated).\r\n* 2. Remove the margin in Firefox and Safari.\r\n*/\r\n\r\nbutton,\r\ninput,\r\noptgroup,\r\nselect,\r\ntextarea {\r\n  font-family: sans-serif; /* 1 */\r\n  font-size: 100%; /* 1 */\r\n  line-height: 1.15; /* 1 */\r\n  margin: 0; /* 2 */\r\n}\r\n\r\n/**\r\n* Show the overflow in IE.\r\n* 1. Show the overflow in Edge.\r\n*/\r\n\r\nbutton,\r\ninput { /* 1 */\r\n  overflow: visible;\r\n}\r\n\r\n/**\r\n* Remove the inheritance of text transform in Edge, Firefox, and IE.\r\n* 1. Remove the inheritance of text transform in Firefox.\r\n*/\r\n\r\nbutton,\r\nselect { /* 1 */\r\n  text-transform: none;\r\n}\r\n\r\n/**\r\n* 1. Prevent a WebKit bug where (2) destroys native `audio` and `video`\r\n*    controls in Android 4.\r\n* 2. Correct the inability to style clickable types in iOS and Safari.\r\n*/\r\n\r\nbutton,\r\nhtml [type=\"button\"], /* 1 */\r\n[type=\"reset\"],\r\n[type=\"submit\"] {\r\n  -webkit-appearance: button; /* 2 */\r\n}\r\n\r\n/**\r\n* Remove the inner border and padding in Firefox.\r\n*/\r\n\r\nbutton::-moz-focus-inner,\r\n[type=\"button\"]::-moz-focus-inner,\r\n[type=\"reset\"]::-moz-focus-inner,\r\n[type=\"submit\"]::-moz-focus-inner {\r\n  border-style: none;\r\n  padding: 0;\r\n}\r\n\r\n/**\r\n* Restore the focus styles unset by the previous rule.\r\n*/\r\n\r\nbutton:-moz-focusring,\r\n[type=\"button\"]:-moz-focusring,\r\n[type=\"reset\"]:-moz-focusring,\r\n[type=\"submit\"]:-moz-focusring {\r\n  outline: 1px dotted ButtonText;\r\n}\r\n\r\n/**\r\n* Correct the padding in Firefox.\r\n*/\r\n\r\nfieldset {\r\n  padding: 0.35em 0.75em 0.625em;\r\n}\r\n\r\n/**\r\n* 1. Correct the text wrapping in Edge and IE.\r\n* 2. Correct the color inheritance from `fieldset` elements in IE.\r\n* 3. Remove the padding so developers are not caught out when they zero out\r\n*    `fieldset` elements in all browsers.\r\n*/\r\n\r\nlegend {\r\n  box-sizing: border-box; /* 1 */\r\n  color: inherit; /* 2 */\r\n  display: table; /* 1 */\r\n  max-width: 100%; /* 1 */\r\n  padding: 0; /* 3 */\r\n  white-space: normal; /* 1 */\r\n}\r\n\r\n/**\r\n* 1. Add the correct display in IE 9-.\r\n* 2. Add the correct vertical alignment in Chrome, Firefox, and Opera.\r\n*/\r\n\r\nprogress {\r\n  display: inline-block; /* 1 */\r\n  vertical-align: baseline; /* 2 */\r\n}\r\n\r\n/**\r\n* Remove the default vertical scrollbar in IE.\r\n*/\r\n\r\ntextarea {\r\n  overflow: auto;\r\n}\r\n\r\n/**\r\n* 1. Add the correct box sizing in IE 10-.\r\n* 2. Remove the padding in IE 10-.\r\n*/\r\n\r\n[type=\"checkbox\"],\r\n[type=\"radio\"] {\r\n  box-sizing: border-box; /* 1 */\r\n  padding: 0; /* 2 */\r\n}\r\n\r\n/**\r\n* Correct the cursor style of increment and decrement buttons in Chrome.\r\n*/\r\n\r\n[type=\"number\"]::-webkit-inner-spin-button,\r\n[type=\"number\"]::-webkit-outer-spin-button {\r\n  height: auto;\r\n}\r\n\r\n/**\r\n* 1. Correct the odd appearance in Chrome and Safari.\r\n* 2. Correct the outline style in Safari.\r\n*/\r\n\r\n[type=\"search\"] {\r\n  -webkit-appearance: textfield; /* 1 */\r\n  outline-offset: -2px; /* 2 */\r\n}\r\n\r\n/**\r\n* Remove the inner padding and cancel buttons in Chrome and Safari on macOS.\r\n*/\r\n\r\n[type=\"search\"]::-webkit-search-cancel-button,\r\n[type=\"search\"]::-webkit-search-decoration {\r\n  -webkit-appearance: none;\r\n}\r\n\r\n/**\r\n* 1. Correct the inability to style clickable types in iOS and Safari.\r\n* 2. Change font properties to `inherit` in Safari.\r\n*/\r\n\r\n::-webkit-file-upload-button {\r\n  -webkit-appearance: button; /* 1 */\r\n  font: inherit; /* 2 */\r\n}\r\n\r\n/* Interactive\r\n ========================================================================== */\r\n\r\n/*\r\n* Add the correct display in IE 9-.\r\n* 1. Add the correct display in Edge, IE, and Firefox.\r\n*/\r\n\r\ndetails, /* 1 */\r\nmenu {\r\n  display: block;\r\n}\r\n\r\n/*\r\n* Add the correct display in all browsers.\r\n*/\r\n\r\nsummary {\r\n  display: list-item;\r\n}\r\n\r\n/* Scripting\r\n ========================================================================== */\r\n\r\n/**\r\n* Add the correct display in IE 9-.\r\n*/\r\n\r\ncanvas {\r\n  display: inline-block;\r\n}\r\n\r\n/**\r\n* Add the correct display in IE.\r\n*/\r\n\r\ntemplate {\r\n  display: none;\r\n}\r\n\r\n/* Hidden\r\n ========================================================================== */\r\n\r\n/**\r\n* Add the correct display in IE 10-.\r\n*/\r\n\r\nbody {\r\n  height: 5000px;\r\n}\r\n\r\n[hidden] {\r\n  display: none;\r\n}\r\n\r\n.fifty {\r\n  width: 50%;\r\n  float: left;\r\n}\r\n\r\n.ng-autocomplete-dropdown {\r\n  position: relative;\r\n  margin-top: 25px;\r\n  height: 200px;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-autocomplete-inputs {\r\n  position: relative;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-autocomplete-inputs input {\r\n  width: 100%;\r\n  padding: 6px 20px;\r\n  font-family: Arial;\r\n  font-weight: normal;\r\n  outline: none !important;\r\n  font-size: 15px;\r\n  height: 56px;\r\n  border: 1px solid #e0e0e0;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-autocomplete-placeholder {\r\n  position: absolute;\r\n  margin: 3px;\r\n  background-color: #fff;\r\n  padding: 17px 18px;\r\n  font-family: Arial;\r\n  font-weight: normal;\r\n  font-size: 15px;\r\n  width: calc(100% - 4px);\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-dropdown {\r\n  display: none;\r\n  border: 1px solid #e0e0e0;\r\n  z-index: 99999;\r\n  max-height: 280px;\r\n  overflow-x: hidden;\r\n  position: absolute;\r\n  width: 100%;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-dropdown.open {\r\n  display: block;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-dropdown .dropdown-item {\r\n  width: 100%;\r\n  cursor: pointer;\r\n  padding: 18px 20px;\r\n  font-family: Arial;\r\n  font-weight: normal;\r\n  font-size: 15px;\r\n  height: 56px;\r\n  background-color: #ffffff;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-dropdown .dropdown-item:nth-child(odd) {\r\n  background-color: #efefef;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-dropdown .dropdown-item.active {\r\n  background-color: #0099cc;\r\n  color: #fff !important;\r\n}\r\n\r\n.ng-autocomplete-dropdown .ng-dropdown .dropdown-item .dropdown-item-highlight {\r\n  font-weight: bold;\r\n}\r\n\r\n.ng-autocomplete-dropdown-icon {\r\n  display: block;\r\n  width: 56px;\r\n  text-align: center;\r\n  position: absolute;\r\n  top: 0;\r\n  bottom: 0;\r\n  right: 0;\r\n  border-left: 1px solid #e0e0e0;\r\n  cursor: pointer;\r\n  z-index: 999;\r\n  font-size: 12px;\r\n  color: #758694;\r\n  padding: 21px 0;\r\n\r\n}\r\n\r\n.ng-autocomplete-dropdown-icon:after {\r\n  content: '';\r\n  display: block;\r\n  width: 0;\r\n  height: 0;\r\n  border-left: 7px solid transparent;\r\n  border-right: 7px solid transparent;\r\n  border-top: 7px solid #000;\r\n  position: absolute;\r\n  right: 21px;\r\n  z-index: 999;\r\n  top: 24px;\r\n}\r\n\r\n.ng-autocomplete-dropdown-icon.open:after {\r\n  -webkit-transform: rotate(180deg);\r\n          transform: rotate(180deg);\r\n}\r\n"

/***/ }),

/***/ "../src/app/transaction/createtransaction.component.html":
/*!***************************************************************!*\
  !*** ../src/app/transaction/createtransaction.component.html ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n <div class=\"content content-custom\">\n  <div class=\"card \">\n    <div class=\"card-header \">\n        <h4 class=\"card-title\">Create Transaction </h4>\n    </div>\n    <div class=\"card-body \">\n      <div class=\"row\">\n       <div class=\"col-md-6\">\n        <form method=\"#\" action=\"#\">\n            <label>Master Code</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"CustomerName\" [(ngModel)]=\"transaction.CustomerCode\"  class=\"form-control col-md-4\"><h5 style=\"color: blue\"> {{CustomerName}}</h5>\n                <a href=\"javascript:;\" class=\"btn btn btn-lg mb-2\" (click)=\"Search(transaction.CustomerCode)\"  style=\"background-color:#b2beb5\"><i class=\"fa fa-search\"></i> Search </a>\n            </div>\n            <label>Amount</label>\n            <div class=\"form-group\">\n                <input type=\"number\" name=\"Amount\"  [(ngModel)]=\"transaction.Amount\" class=\"form-control col-md-4\">\n            </div>\n        </form>\n       </div>\n      </div>\n\n    </div>\n    <div class=\"card-footer \">\n        <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" (click)=\"Ok(transaction)\" style=\"background-color: orange\">Save Transaction </a>\n\n        &nbsp; <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" [routerLink]=\"['/transactionlog']\" style=\"background-color:#b2beb5\" > Back to List </a>\n    </div>\n</div>\n</div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/transaction/createtransaction.component.ts":
/*!*************************************************************!*\
  !*** ../src/app/transaction/createtransaction.component.ts ***!
  \*************************************************************/
/*! exports provided: CreateTransactionComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreateTransactionComponent", function() { return CreateTransactionComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/transaction.service */ "../src/app/service/transaction.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var CreateTransactionComponent = /** @class */ (function () {
    function CreateTransactionComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        // @ViewChild(NgAutocompleteComponent) public completer: NgAutocompleteComponent;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.transaction = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["TransactionLogger"]();
    }
    CreateTransactionComponent.prototype.ngOnInit = function () {
    };
    CreateTransactionComponent.prototype.Search = function (search) {
        this.CustomerName = '';
        if (search === null || search === undefined) {
            this.toastr.error('customer code cannot be empty', 'Error Message');
        }
        var self = this;
        this.service.getCustomerNameByCode(search).subscribe(function (c) {
            if (c.Succeeded) {
                self.CustomerName = c.Result;
            }
            else {
                self.CustomerName = null;
                self.transaction.CustomerCode = null;
                self.toastr.error('Customer information not found', 'Error Message');
            }
        }, function (e) {
            self.CustomerName = null;
            self.transaction.CustomerCode = null;
            self.toastr.error('Customer information not found', 'Error Message');
        });
    };
    CreateTransactionComponent.prototype.Ok = function (model) {
        if (model == null) {
            this.toastr.error('transaction posting cannot be empty', 'Error Message');
            return;
        }
        if (model.Amount <= 0) {
            this.toastr.error('transaction amount cannot be less than zero', 'Error Message');
            return;
        }
        if (model.CustomerCode == null || model.CustomerCode === '') {
            this.toastr.error('Customer code amount cannot be empty', 'Error Message');
            return;
        }
        var self = this;
        this.service.PostTransactionLog(model).subscribe(function (c) {
            if (c.Succeeded) {
                model.Amount = 0;
                model.CustomerCode = '';
                self.toastr.success('Operation successful', 'Success');
            }
            else {
                model.Amount = 0;
                model.CustomerCode = '';
                self.toastr.error('Operation failed ', 'Error Message');
            }
        }, function (e) {
            model.Amount = 0;
            model.CustomerCode = '';
            self.toastr.error('Transaction failed to create', 'Error Message');
        });
    };
    CreateTransactionComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-createtransaction',
            template: __webpack_require__(/*! ./createtransaction.component.html */ "../src/app/transaction/createtransaction.component.html"),
            styles: [__webpack_require__(/*! ./createtransaction.component.css */ "../src/app/transaction/createtransaction.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__["TransactionService"]])
    ], CreateTransactionComponent);
    return CreateTransactionComponent;
}());



/***/ }),

/***/ "../src/app/transaction/credittransaction.component.html":
/*!***************************************************************!*\
  !*** ../src/app/transaction/credittransaction.component.html ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">Credit Transactions List</h5>\n              <p>The list shows all the   <code>credit</code> transaction\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <!-- <a href=\"javascript:;\" class=\"btn btn-default btn-sm\"><i class=\"fa fa-plus\"></i> Add Transaction </a> -->\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control form-control-sm mar-5\" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchString\" type=\"text\">\n                          <!-- <select class=\"form-control form-control-sm\">\n                              <option selected=\"selected\" value=\"\">\n                                  Select Status\n                              </option>\n                              <option value=\"Pending\">\n                                  Pending\n                              </option>\n                              <option value=\"Completed\">\n                                  Completed\n                              </option>\n                              <option value=\"Cancelled\">\n                                  Cancelled\n                              </option>\n                          </select> -->\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>Transaction No</th>\n                              <th>Transaction Type</th>\n                              <th>Customer Name</th>\n                              <th>Customer Code</th>\n                              <!-- <th>Transaction Message </th> -->\n                              <th>Amount</th>\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of transactions; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.TransactionNo}}</td>\n                              <td>{{item.TransactionType}}</td>\n                              <td>{{item.Customer.LastName}} {{item.Customer.FirstName}} </td>\n                              <td>{{item.Customer.CustomerCode}}</td>\n                              <!-- <td>{{item.TransactionMessage}}</td> -->\n                              <td>₦{{item.Amount}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No transaction found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/transaction/credittransaction.component.ts":
/*!*************************************************************!*\
  !*** ../src/app/transaction/credittransaction.component.ts ***!
  \*************************************************************/
/*! exports provided: CreditTransactionComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreditTransactionComponent", function() { return CreditTransactionComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/transaction.service */ "../src/app/service/transaction.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var CreditTransactionComponent = /** @class */ (function () {
    function CreditTransactionComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.transactions = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
    }
    CreditTransactionComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    CreditTransactionComponent.prototype.GetStatus = function (status) {
    };
    CreditTransactionComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    CreditTransactionComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    CreditTransactionComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0;
        return result;
    };
    CreditTransactionComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getCreditTransaction(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.transactions = self.data.Page;
            }
            return self.transactions;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.transactions;
        });
        return self.transactions;
    };
    CreditTransactionComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-credittransaction',
            template: __webpack_require__(/*! ./credittransaction.component.html */ "../src/app/transaction/credittransaction.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__["TransactionService"]])
    ], CreditTransactionComponent);
    return CreditTransactionComponent;
}());



/***/ }),

/***/ "../src/app/transaction/debittransaction.component.html":
/*!**************************************************************!*\
  !*** ../src/app/transaction/debittransaction.component.html ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">Debit Transactions List</h5>\n              <p>The list shows all the   <code>debit</code> transaction\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <!-- <a href=\"javascript:;\" class=\"btn btn-default btn-sm\"><i class=\"fa fa-plus\"></i> Add Transaction </a> -->\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control form-control-sm mar-5\" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchString\" type=\"text\">\n                          <!-- <select class=\"form-control form-control-sm\">\n                              <option selected=\"selected\" value=\"\">\n                                  Select Status\n                              </option>\n                              <option value=\"Pending\">\n                                  Pending\n                              </option>\n                              <option value=\"Completed\">\n                                  Completed\n                              </option>\n                              <option value=\"Cancelled\">\n                                  Cancelled\n                              </option>\n                          </select> -->\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>Transaction No</th>\n                              <th>Transaction Type</th>\n                              <th>Customer Name</th>\n                              <th>Customer Code</th>\n                              <!-- <th>Transaction Message </th> -->\n                              <th>Amount</th>\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of transactions; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.TransactionNo}}</td>\n                              <td>{{item.TransactionType}}</td>\n                              <td>{{item.Customer.LastName}} {{item.Customer.FirstName}} </td>\n                              <td>{{item.Customer.CustomerCode}}</td>\n                              <!-- <td>{{item.TransactionMessage}}</td> -->\n                              <td>₦{{item.Amount}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No transaction found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/transaction/debittransaction.component.ts":
/*!************************************************************!*\
  !*** ../src/app/transaction/debittransaction.component.ts ***!
  \************************************************************/
/*! exports provided: DebitTransactionComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DebitTransactionComponent", function() { return DebitTransactionComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/transaction.service */ "../src/app/service/transaction.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var DebitTransactionComponent = /** @class */ (function () {
    function DebitTransactionComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.transactions = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
    }
    DebitTransactionComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    DebitTransactionComponent.prototype.GetStatus = function (status) {
    };
    DebitTransactionComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    DebitTransactionComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    DebitTransactionComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0;
        return result;
    };
    DebitTransactionComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getDebitTransaction(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.transactions = self.data.Page;
            }
            return self.transactions;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.transactions;
        });
        return self.transactions;
    };
    DebitTransactionComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-debittransaction',
            template: __webpack_require__(/*! ./debittransaction.component.html */ "../src/app/transaction/debittransaction.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__["TransactionService"]])
    ], DebitTransactionComponent);
    return DebitTransactionComponent;
}());



/***/ }),

/***/ "../src/app/transaction/transaction.component.html":
/*!*********************************************************!*\
  !*** ../src/app/transaction/transaction.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">All Transactions Report</h5>\n              <p>The list shows all the transaction either <code>credit</code>  or <code>debit</code>\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" (click)=\"reloadPage()\">Refresh </a>\n                      <!-- <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" [routerLink]=\"['/createtransaction']\" ><i class=\"fa fa-plus\"></i> Add Transaction </a> -->\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control \" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchModel.Search\" type=\"text\">\n                          &nbsp; <span>StartDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"stardate\" name=\"stardate\" [(ngModel)]=\"searchModel.StartDate\" >\n                          &nbsp; <span>EndDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"enddate\" name=\"enddate\" [(ngModel)]=\"searchModel.EndDate\" >\n                          &nbsp;\n                          <a href=\"javascript:;\" class=\"btn btn btn-sm mb-2\" (click)=\"SearchTransaction(searchModel)\"  style=\"background-color: orange\"><i class=\"fa fa-search\"></i>Search </a>\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered\">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>Transaction No</th>\n                              <th>Transaction Type</th>\n                              <th>Customer Name</th>\n                              <th>Customer Code</th>\n                              <th>Merchant Name</th>\n                              <th>Agent Name</th>\n                              <th>Amount</th>\n                              <th>Entry Date </th>\n                              <th>Approval </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of transactions; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.TransactionNo}}</td>\n                              <td>{{item.TransactionType}}</td>\n                              <td>{{item.Customer.LastName}} {{item.Customer.FirstName}} </td>\n                              <td>{{item.Customer.CustomerCode}}</td>\n                              <td>{{item.MerchantName}}</td>\n                              <td>{{item.AgentName}}</td>\n                              <td>₦{{item.Amount}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                              <td>Approved</td>\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No transaction found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/transaction/transaction.component.ts":
/*!*******************************************************!*\
  !*** ../src/app/transaction/transaction.component.ts ***!
  \*******************************************************/
/*! exports provided: TransactionComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TransactionComponent", function() { return TransactionComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_transaction_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/transaction.service */ "../src/app/service/transaction.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var TransactionComponent = /** @class */ (function () {
    function TransactionComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.transactions = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.searchModel = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["SearchModel"]();
    }
    TransactionComponent.prototype.reloadPage = function () {
        document.location.reload();
    };
    TransactionComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    TransactionComponent.prototype.GetStatus = function (status) {
    };
    TransactionComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    TransactionComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    TransactionComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0;
        return result;
    };
    TransactionComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getTransaction(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.transactions = self.data.Page;
            }
            return self.transactions;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.transactions;
        });
        return self.transactions;
    };
    TransactionComponent.prototype.SearchTransaction = function (searchMod) {
        var self = this;
        self.service.getTransactionSearch(searchMod).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.transactions = self.data.Page;
            }
            return self.transactions;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.transactions;
        });
        return self.transactions;
    };
    TransactionComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-transaction',
            template: __webpack_require__(/*! ./transaction.component.html */ "../src/app/transaction/transaction.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_transaction_service__WEBPACK_IMPORTED_MODULE_7__["TransactionService"]])
    ], TransactionComponent);
    return TransactionComponent;
}());



/***/ }),

/***/ "../src/app/transaction/transactionlog.component.html":
/*!************************************************************!*\
  !*** ../src/app/transaction/transactionlog.component.html ***!
  \************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">Transaction Log List</h5>\n              <p>The list shows all <code>credit</code> transaction logs\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" [routerLink]=\"['/createtransaction']\" ><i class=\"fa fa-plus\"></i> Add Transaction </a>\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control form-control-sm mar-5\" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchString\" type=\"text\">\n                          <!-- <select class=\"form-control form-control-sm\">\n                              <option selected=\"selected\" value=\"\">\n                                  Select Status\n                              </option>\n                              <option value=\"Pending\">\n                                  Pending\n                              </option>\n                              <option value=\"Completed\">\n                                  Completed\n                              </option>\n                              <option value=\"Cancelled\">\n                                  Cancelled\n                              </option>\n                          </select> -->\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>Transaction No</th>\n                              <th>Transaction Type</th>\n                              <th>Customer Name</th>\n                              <th>Merchant Name</th>\n                              <th>Agent Name</th>\n                              <th>Customer Code</th>\n                              <th>Amount</th>\n                              <th>Transaction Status</th>\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of transactions; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.TransactionNo}}</td>\n                              <td>{{item.TransactionType}}</td>\n                              <td>{{item.Customer.LastName}} {{item.Customer.FirstName}} </td>\n                              <td>{{item.MerchantName}}</td>\n                              <td>{{item.AgentName}}</td>\n                              <td>{{item.Customer.CustomerCode}}</td>\n                              <td>₦{{item.Amount}}</td>\n                              <td>{{item.IsApproved ? 'Approved' :'Pending' }}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                              <td *ngIf=\"roleName == 'Merchant Admin'\">\n                              <a href=\"javascript:;\" class=\"btn btn-sm mb-3\" (click)=\"ApproveTransaction(item.Id)\" style=\"background-color:orange\">Approve </a> &nbsp;\n                              <a href=\"javascript:;\" class=\"btn btn-sm mb-3\" (click)=\"DeclineTransaction(item.Id)\" style=\"background-color:#b2beb5\" > Decline </a>\n                              </td>\n                          </tr>\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No Transaction found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/transaction/transactionlog.component.ts":
/*!**********************************************************!*\
  !*** ../src/app/transaction/transactionlog.component.ts ***!
  \**********************************************************/
/*! exports provided: TransactionLogComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TransactionLogComponent", function() { return TransactionLogComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/transaction.service */ "../src/app/service/transaction.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var TransactionLogComponent = /** @class */ (function () {
    function TransactionLogComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.transactions = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
    }
    TransactionLogComponent.prototype.ngOnInit = function () {
        this.roleName = this.storage.GetUserInfo().Role;
        this.LoadFirstPage();
    };
    TransactionLogComponent.prototype.GetStatus = function (status) { };
    TransactionLogComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    TransactionLogComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get(Math.ceil(this.data.SequenceLength / this.pageSize) - 1);
        }
    };
    TransactionLogComponent.prototype.HasNoPage = function () {
        var result = this.data == null ||
            typeof this.data === "undefined" ||
            this.data.Page.length === 0;
        return result;
    };
    TransactionLogComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getTransactionLog(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.transactions = self.data.Page;
            }
            return self.transactions;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.transactions;
        });
        return self.transactions;
    };
    TransactionLogComponent.prototype.DeclineTransaction = function (id) {
        var self = this;
        if (!confirm("Are you sure")) {
            self.toastr.success("operation cancelled successfully", "Success");
            return;
        }
        this.service.DelineTransaction(id).subscribe(function (c) {
            if (c.Succeeded) {
                self.LoadFirstPage();
                self.toastr.success("Operation Successful");
            }
            else {
                self.toastr.error("Operation failed");
            }
        }, function (e) {
            self.toastr.error("Operation failed");
        });
    };
    TransactionLogComponent.prototype.ApproveTransaction = function (id) {
        var self = this;
        this.service.ApproveTransaction(id).subscribe(function (c) {
            if (c.Succeeded) {
                self.LoadFirstPage();
                self.toastr.success("Operation Successful");
            }
            else {
                self.toastr.error("Operation failed");
            }
        }, function (e) {
            self.toastr.error("Operation failed");
        });
    };
    TransactionLogComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-transactionlog",
            template: __webpack_require__(/*! ./transactionlog.component.html */ "../src/app/transaction/transactionlog.component.html")
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"],
            _service_transaction_service__WEBPACK_IMPORTED_MODULE_6__["TransactionService"]])
    ], TransactionLogComponent);
    return TransactionLogComponent;
}());



/***/ }),

/***/ "../src/app/withdrawal/approvedwithdrawal.component.html":
/*!***************************************************************!*\
  !*** ../src/app/withdrawal/approvedwithdrawal.component.html ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">Approved Withdrawal List</h5>\n              <p>The list shows all the  <code>approved</code> withdrawals\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <!-- <a href=\"javascript:;\" class=\"btn btn-default btn-sm\"><i class=\"fa fa-plus\"></i> Add Transaction </a> -->\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control form-control-sm mar-5\" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchString\" type=\"text\">\n                          <!-- <select class=\"form-control form-control-sm\">\n                              <option selected=\"selected\" value=\"\">\n                                  Select Status\n                              </option>\n                              <option value=\"Pending\">\n                                  Pending\n                              </option>\n                              <option value=\"Completed\">\n                                  Completed\n                              </option>\n                              <option value=\"Cancelled\">\n                                  Cancelled\n                              </option>\n                          </select> -->\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered\">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>Customer Name </th>\n                              <th>Customer Code</th>\n                              <th>Amount</th>\n                              <th>Withdrawal Status</th>\n                              <th>Reason</th>\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of response; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.Customer.FirstName}} {{item.Customer.LastName}}</td>\n                              <td>{{item.Customer.CustomerCode}} </td>\n                              <td>₦{{item.Amount}} </td>\n                              <td> {{GetWithdrawalStatus(item.WithdrawalStatus)}}</td>\n                              <td>{{item.Message}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No Customer found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/withdrawal/approvedwithdrawal.component.ts":
/*!*************************************************************!*\
  !*** ../src/app/withdrawal/approvedwithdrawal.component.ts ***!
  \*************************************************************/
/*! exports provided: ApprovedWithdrawalComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ApprovedWithdrawalComponent", function() { return ApprovedWithdrawalComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/withdrawal.service */ "../src/app/service/withdrawal.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var ApprovedWithdrawalComponent = /** @class */ (function () {
    function ApprovedWithdrawalComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.response = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
    }
    ApprovedWithdrawalComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    ApprovedWithdrawalComponent.prototype.GetStatus = function (status) {
    };
    ApprovedWithdrawalComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    ApprovedWithdrawalComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    ApprovedWithdrawalComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0;
        return result;
    };
    ApprovedWithdrawalComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getApproveWithdrawal(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_5__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    ApprovedWithdrawalComponent.prototype.GetWithdrawalStatus = function (status) {
        if (status === 0) {
            return 'Pending';
        }
        else if (status === 1) {
            return 'Approved';
        }
        else if (status === 2) {
            return 'Paid';
        }
    };
    ApprovedWithdrawalComponent.prototype.ViewCustomer = function (id) {
    };
    ApprovedWithdrawalComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-approvedwithdrawal',
            template: __webpack_require__(/*! ./approvedwithdrawal.component.html */ "../src/app/withdrawal/approvedwithdrawal.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_6__["WithdrawalService"]])
    ], ApprovedWithdrawalComponent);
    return ApprovedWithdrawalComponent;
}());



/***/ }),

/***/ "../src/app/withdrawal/createwithdrawal.component.html":
/*!*************************************************************!*\
  !*** ../src/app/withdrawal/createwithdrawal.component.html ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n <div class=\"content content-custom\">\n  <div class=\"card \">\n    <div class=\"card-header \">\n        <h4 class=\"card-title\">Create Withdrawal </h4>\n    </div>\n    <div class=\"card-body \">\n      <div class=\"row\">\n       <div class=\"col-md-6\">\n        <form method=\"#\" action=\"#\">\n            <label>Master Code</label>\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"CustomerName\" [(ngModel)]=\"withdrawal.CustomerCode\"  class=\"form-control col-md-4\"><h5 style=\"color: blue\"> {{CustomerName}}</h5>\n                <a href=\"javascript:;\" class=\"btn btn btn-lg mb-2\" (click)=\"Search(withdrawal.CustomerCode)\"  style=\"background-color:#b2beb5\"><i class=\"fa fa-search\"></i> Search </a>\n            </div>\n            <label>Amount</label>\n            <div class=\"form-group\">\n                <input type=\"number\" name=\"Amount\"  [(ngModel)]=\"withdrawal.Amount\" class=\"form-control col-md-4\">\n            </div>\n        </form>\n       </div>\n      </div>\n\n    </div>\n    <div class=\"card-footer \">\n        <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" (click)=\"Ok(withdrawal)\" style=\"background-color: orange\">Save Withdrawal </a>\n\n        &nbsp; <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" [routerLink]=\"['/withdrawal']\" style=\"background-color:#b2beb5\" > Back to List </a>\n    </div>\n</div>\n</div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/withdrawal/createwithdrawal.component.ts":
/*!***********************************************************!*\
  !*** ../src/app/withdrawal/createwithdrawal.component.ts ***!
  \***********************************************************/
/*! exports provided: CreateWithdrawalComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreateWithdrawalComponent", function() { return CreateWithdrawalComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/withdrawal.service */ "../src/app/service/withdrawal.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var CreateWithdrawalComponent = /** @class */ (function () {
    function CreateWithdrawalComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        // @ViewChild(NgAutocompleteComponent) public completer: NgAutocompleteComponent;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.withdrawal = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["WithdrawalLogger"]();
    }
    CreateWithdrawalComponent.prototype.ngOnInit = function () {
    };
    CreateWithdrawalComponent.prototype.Search = function (search) {
        this.CustomerName = '';
        if (search === null || search === undefined) {
            this.toastr.error('customer code cannot be empty', 'Error Message');
        }
        var self = this;
        this.service.getCustomerNameByCode(search).subscribe(function (c) {
            if (c.Succeeded) {
                self.CustomerName = c.Result;
            }
            else {
                self.CustomerName = null;
                self.withdrawal.CustomerCode = null;
                self.toastr.error('Customer information not found', 'Error Message');
            }
        }, function (e) {
            self.CustomerName = null;
            self.withdrawal.CustomerCode = null;
            self.toastr.error('Customer information not found', 'Error Message');
        });
    };
    CreateWithdrawalComponent.prototype.Ok = function (model) {
        if (model == null) {
            this.toastr.error('withdrawal posting cannot be empty', 'Error Message');
            return;
        }
        if (model.Amount <= 0) {
            this.toastr.error('withdrawal amount cannot be less than zero', 'Error Message');
            return;
        }
        if (model.CustomerCode == null || model.CustomerCode === '') {
            this.toastr.error('Customer code amount cannot be empty', 'Error Message');
            return;
        }
        var self = this;
        this.service.PostWithdrawal(model).subscribe(function (c) {
            if (c.Succeeded) {
                model.Amount = 0;
                model.CustomerCode = '';
                self.toastr.success('Operation successful', 'Success');
            }
            else {
                model.Amount = 0;
                model.CustomerCode = '';
                self.toastr.error('Operation failed ' + c.Message, 'Error Message');
            }
        }, function (e) {
            model.Amount = 0;
            model.CustomerCode = '';
            self.toastr.error('Transaction failed to create', 'Error Message');
        });
    };
    CreateWithdrawalComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-createwithdrawal',
            template: __webpack_require__(/*! ./createwithdrawal.component.html */ "../src/app/withdrawal/createwithdrawal.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_6__["WithdrawalService"]])
    ], CreateWithdrawalComponent);
    return CreateWithdrawalComponent;
}());



/***/ }),

/***/ "../src/app/withdrawal/paidwithdrawal.component.html":
/*!***********************************************************!*\
  !*** ../src/app/withdrawal/paidwithdrawal.component.html ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">Paid Withdrawal List</h5>\n              <p>The list shows all the   <code>Paid</code> withdrawals\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <!-- <a href=\"javascript:;\" class=\"btn btn-default btn-sm\"><i class=\"fa fa-plus\"></i> Add Transaction </a> -->\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control form-control-sm mar-5\" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchString\" type=\"text\">\n                          <!-- <select class=\"form-control form-control-sm\">\n                              <option selected=\"selected\" value=\"\">\n                                  Select Status\n                              </option>\n                              <option value=\"Pending\">\n                                  Pending\n                              </option>\n                              <option value=\"Completed\">\n                                  Completed\n                              </option>\n                              <option value=\"Cancelled\">\n                                  Cancelled\n                              </option>\n                          </select> -->\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>Customer Name </th>\n                              <th>Customer Code</th>\n                              <th>Amount</th>\n                              <th>Withdrawal Status</th>\n                              <th>Reason</th>\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of response; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.Customer.FirstName}} {{item.Customer.LastName}}</td>\n                              <td>{{item.Customer.CustomerCode}} </td>\n                              <td>₦{{item.Amount}} </td>\n                              <td> {{GetWithdrawalStatus(item.WithdrawalStatus)}}</td>\n                              <td>{{item.Message}}</td>\n                              <td>{{item.CreatedDate | date }}</td>\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No Customer found</span>\n                    </div>\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/withdrawal/paidwithdrawal.component.ts":
/*!*********************************************************!*\
  !*** ../src/app/withdrawal/paidwithdrawal.component.ts ***!
  \*********************************************************/
/*! exports provided: PaidWithdrawalComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PaidWithdrawalComponent", function() { return PaidWithdrawalComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/withdrawal.service */ "../src/app/service/withdrawal.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var PaidWithdrawalComponent = /** @class */ (function () {
    function PaidWithdrawalComponent(router, toastr, storage, spinnerService, service) {
        this.router = router;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.response = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.WithdrawalStatus = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["WithdrawalStatus"]();
    }
    PaidWithdrawalComponent.prototype.ngOnInit = function () {
        this.LoadFirstPage();
    };
    PaidWithdrawalComponent.prototype.GetStatus = function (status) {
    };
    PaidWithdrawalComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    PaidWithdrawalComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get((Math.ceil(this.data.SequenceLength / this.pageSize) - 1));
        }
    };
    PaidWithdrawalComponent.prototype.HasNoPage = function () {
        var result = this.data == null
            || typeof this.data === 'undefined'
            || this.data.Page.length === 0;
        return result;
    };
    PaidWithdrawalComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getPaidWithdrawal(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    PaidWithdrawalComponent.prototype.GetWithdrawalStatus = function (status) {
        if (status === 0) {
            return 'Pending';
        }
        else if (status === 1) {
            return 'Approved';
        }
        else if (status === 2) {
            return 'Paid';
        }
    };
    PaidWithdrawalComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-paidwithdrawal',
            template: __webpack_require__(/*! ./paidwithdrawal.component.html */ "../src/app/withdrawal/paidwithdrawal.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_7__["WithdrawalService"]])
    ], PaidWithdrawalComponent);
    return PaidWithdrawalComponent;
}());



/***/ }),

/***/ "../src/app/withdrawal/withdrawal.component.html":
/*!*******************************************************!*\
  !*** ../src/app/withdrawal/withdrawal.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n     <div class=\"content content-custom\">\n      <div class=\"card\">\n          <div class=\"card-header\">\n              <h5 class=\"title\">All Withdrawal Report </h5>\n              <p>The list shows all the withdrawal either <code>approved</code>  or <code>paid</code>\n          </p>\n              <hr>\n              <div class=\"row\">\n                  <div class=\"col-sm-6\">\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" [routerLink]=\"['/createwithdrawal']\"><i class=\"fa fa-plus\"></i> Add Withdrawal </a> &nbsp;\n                      <a href=\"javascript:;\" class=\"btn btn-default btn-sm\" (click)=\"reloadPage()\">Refresh </a>\n                      <!-- <a href=\"#\" class=\"btn btn-default btn-sm\">Archive</a>\n                      <a href=\"#\" class=\"btn btn-danger btn-sm\">Delete</a> -->\n                  </div>\n                  <div class=\"col-sm-6\">\n                      <form class=\"form-inline justify-content-sm-end\">\n                          <input class=\"form-control \" placeholder=\"Search\" name=\"searchString\" [(ngModel)]=\"searchModel.Search\" type=\"text\">\n                          &nbsp; <span>StartDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"stardate\" name=\"stardate\" [(ngModel)]=\"searchModel.StartDate\" >\n                          &nbsp; <span>EndDate</span>\n                          <input type=\"date\" class=\"form-control\" placeholder=\"enddate\" name=\"enddate\" [(ngModel)]=\"searchModel.EndDate\" >\n                          &nbsp;\n                          <a href=\"javascript:;\" class=\"btn btn btn-sm mb-2\" (click)=\"SearchWithdrawal(searchModel)\"  style=\"background-color: orange\"><i class=\"fa fa-search\"></i>Search </a>\n                      </form>\n                  </div>\n              </div>\n          </div>\n          <div class=\"card-body\">\n              <div class=\"table-fixed\" style=\"overflow: scroll; height: 800px\">\n\n                  <table class=\"table table-bordered \">\n                      <thead>\n                          <tr class=\"h6\">\n                              <th>SN</th>\n                              <th>Customer Name </th>\n                              <th>Customer Code</th>\n                              <th>Amount</th>\n                              <th>Withdrawal Status</th>\n                              <!-- <th>Reason</th> -->\n                              <th>Entry Date </th>\n                          </tr>\n                      </thead>\n                      <tbody>\n                          <tr *ngFor=\"let item of response; let i=index \">\n                              <td>{{i+1}}</td>\n                              <td>{{item.Customer.FirstName}} {{item.Customer.LastName}}</td>\n                              <td>{{item.Customer.CustomerCode}} </td>\n                              <td>₦{{item.Amount}} </td>\n                              <td>{{GetWithdrawalStatus(item.WithdrawalStatus)}}</td>\n                              <!-- <td>{{item.Message}}</td> -->\n                              <td>{{item.CreatedDate | date }}</td>\n                              <td *ngIf=\"roleName == 'Merchant Admin'\">\n                                  <a href=\"javascript:;\" [hidden]=\"GetWithdrawalStatus(item.WithdrawalStatus) === 'Paid' \" class=\"btn btn-sm mb-3\" (click)=\"ShowApprovalForm(item.Id)\" style=\"background-color:orange\">Approve </a> &nbsp;\n                                  <a href=\"javascript:;\" [hidden]=\"GetWithdrawalStatus(item.WithdrawalStatus) === 'Paid' \" class=\"btn btn-sm mb-3\" (click)=\"DeclineWithdrawal(item.Id)\" style=\"background-color:#b2beb5\" >Decline </a>\n                              </td>\n                          </tr>\n\n                      </tbody>\n                  </table>\n                  <!-- <div *ngIf=\"!hasPage\" style=\"text-align: center; font-size:18px; margin-top:20px;\">\n                      <span class=\"text-muted\" style=\"font-size:22px;\">No Withdrawal found</span>\n                    </div> -->\n\n                    <div class=\"row\">\n                      <div class=\"col-lg-12\" style=\"text-align:right\">\n                        <ul class=\"pagination\">\n                          <li style=\"font-size:18px;\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\"  (click)=\"LoadFirstPage()\"> &laquo; &nbsp; </a> </li>\n                          <li *ngFor=\"let p of pageLinks\" style=\"font-size:18px;\">\n                            <a href=\"javascript:void(0)\" class=\"page-link\" (click)=\"Get(p)\">\n                              {{p + 1}}\n                            </a>\n                          </li>\n                          <li style=\"font-size:18px\"><a href=\"javascript:void(0)\" style=\"text-decoration:none\" (click)=\"LoadLastPage()\" >&nbsp;  &raquo; </a></li>\n                        </ul>\n                      </div>\n                    </div>\n              </div>\n          </div>\n      </div>\n  </div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/withdrawal/withdrawal.component.ts":
/*!*****************************************************!*\
  !*** ../src/app/withdrawal/withdrawal.component.ts ***!
  \*****************************************************/
/*! exports provided: WithdrawalComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WithdrawalComponent", function() { return WithdrawalComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/sequencepage */ "../src/app/shared/sequencepage.ts");
/* harmony import */ var _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../service/withdrawal.service */ "../src/app/service/withdrawal.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var WithdrawalComponent = /** @class */ (function () {
    function WithdrawalComponent(router, route, toastr, storage, spinnerService, service) {
        this.router = router;
        this.route = route;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + "//" + location.host + "/";
        this.response = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.withd = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["WithdrawApprovalModel"]();
        this.searchModel = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["SearchModel"]();
    }
    WithdrawalComponent.prototype.reloadPage = function () {
        document.location.reload();
    };
    WithdrawalComponent.prototype.ngOnInit = function () {
        this.roleName = this.storage.GetUserInfo().Role;
        this.LoadFirstPage();
    };
    WithdrawalComponent.prototype.LoadFirstPage = function () {
        var get = this.Get(0);
        this.hasPage = this.HasNoPage();
        return get;
    };
    WithdrawalComponent.prototype.LoadLastPage = function () {
        if (this.data) {
            return this.Get(Math.ceil(this.data.SequenceLength / this.pageSize) - 1);
        }
    };
    WithdrawalComponent.prototype.HasNoPage = function () {
        var result = this.data == null ||
            typeof this.data === "undefined" ||
            this.data.Page.length === 0;
        return result;
    };
    WithdrawalComponent.prototype.ShowApprovalForm = function (id) {
        // const wid = this.route.snapshot.paramMap.get('id');
        this.router.navigate(["/withdrawalagent", id]);
    };
    WithdrawalComponent.prototype.Get = function (pageIndex) {
        var self = this;
        self.service.getWithdrawal(pageIndex, this.pageSize).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    WithdrawalComponent.prototype.GetWithdrawalStatus = function (status) {
        if (status === 0) {
            return "Pending";
        }
        else if (status === 1) {
            return "Approved";
        }
        else if (status === 2) {
            return "Paid";
        }
    };
    // WithdrawalDecline
    WithdrawalComponent.prototype.ApproveWithdrawal = function (id) {
        var self = this;
        this.withd.WithdrawalId = id;
        this.withd.AgentUserId = 0;
        this.service.WithdrawalApproval(this.withd).subscribe(function (c) {
            if (c.Succeeded) {
                self.LoadFirstPage();
                self.toastr.success("Operation Successful");
            }
            else {
                self.toastr.error(c.Message);
            }
        }, function (e) {
            self.toastr.error("Operation failed " + e);
        });
    };
    WithdrawalComponent.prototype.DeclineWithdrawal = function (id) {
        var self = this;
        if (!confirm("Are you sure")) {
            self.toastr.success("operation cancelled successfully", "Success");
            return;
        }
        this.service.WithdrawalDecline(id).subscribe(function (c) {
            if (c.Succeeded) {
                self.LoadFirstPage();
                self.toastr.success("Operation Successful");
            }
            else {
                self.toastr.error(c.Message);
            }
        }, function (e) {
            self.toastr.error("Operation failed " + e);
        });
    };
    WithdrawalComponent.prototype.SearchWithdrawal = function (searchMod) {
        var self = this;
        self.service.getWithdrawalSearch(searchMod).subscribe(function (resp) {
            var _page = resp.Result;
            if (_page.PageSize === 0) {
                // <-- debug stuff
                self.pageLinks = [];
            }
            else {
                self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"](_page.Page, _page.SequenceLength, _page.PageSize, _page.PageIndex);
                self.pageLinks = self.data.AdjacentIndexes(2);
                self.response = self.data.Page;
            }
            return self.response;
        }, function (err) {
            self.data = new _shared_sequencepage__WEBPACK_IMPORTED_MODULE_6__["SequencePage"]([], 0);
            self.pageLinks = self.data.AdjacentIndexes(2);
            return self.response;
        });
        return self.response;
    };
    WithdrawalComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "app-withdrawal",
            template: __webpack_require__(/*! ./withdrawal.component.html */ "../src/app/withdrawal/withdrawal.component.html")
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"],
            _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"],
            _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_7__["WithdrawalService"]])
    ], WithdrawalComponent);
    return WithdrawalComponent;
}());



/***/ }),

/***/ "../src/app/withdrawal/withdrawalagent.component.html":
/*!************************************************************!*\
  !*** ../src/app/withdrawal/withdrawalagent.component.html ***!
  \************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"wrapper\" style=\"overflow: scroll\">\n  <app-navigation></app-navigation>\n  <div class=\"main-panel ps-container ps-theme-default ps-active-y\"  data-ps-id=\"b6cf33ed-96e2-9b09-5a3a-775d748c89a4\">\n  <app-topnav></app-topnav>\n  <div class=\"panel-header panel-header-sm panel-header-custom\">\n </div>\n <div class=\"content content-custom\">\n  <div class=\"card \">\n    <div class=\"card-header \">\n        <h4 class=\"card-title\">Merchant Agent </h4>\n    </div>\n    <div class=\"card-body \">\n      <div class=\"row\">\n       <div class=\"col-md-6\">\n        <form method=\"#\" action=\"#\">\n            <label>Agent Name</label>\n                 <select class=\"form-control form-control-sm\" name=\"role\" [(ngModel)]=\"withd.AgentUserId\">\n                      <option *ngFor=\"let item of agentUserAdmins\" value=\"{{item.AgentUserId}}\">\n                         {{item.Name}}\n                       </option>\n                 </select>\n        </form>\n       </div>\n      </div>\n\n    </div>\n    <div class=\"card-footer \">\n        <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" (click)=\"ApproveWithdrawal(withd)\" style=\"background-color: orange\">Post Withdrawal </a>\n        &nbsp; <a href=\"javascript:;\" class=\"btn btn btn-lg mb-3\" [routerLink]=\"['/withdrawal']\" style=\"background-color:#b2beb5\" > Back to List </a>\n    </div>\n</div>\n</div>\n\n </div>\n </div>\n\n\n"

/***/ }),

/***/ "../src/app/withdrawal/withdrawalagent.component.ts":
/*!**********************************************************!*\
  !*** ../src/app/withdrawal/withdrawalagent.component.ts ***!
  \**********************************************************/
/*! exports provided: WithdrawalAgentComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WithdrawalAgentComponent", function() { return WithdrawalAgentComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "../node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _service_storage_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../service/storage.service */ "../src/app/service/storage.service.ts");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng4-loading-spinner */ "../node_modules/ng4-loading-spinner/ng4-loading-spinner.umd.js");
/* harmony import */ var ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "../node_modules/ngx-toastr/fesm5/ngx-toastr.js");
/* harmony import */ var _shared_model__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/model */ "../src/app/shared/model.ts");
/* harmony import */ var _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../service/withdrawal.service */ "../src/app/service/withdrawal.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var WithdrawalAgentComponent = /** @class */ (function () {
    function WithdrawalAgentComponent(router, route, toastr, storage, spinnerService, service) {
        this.router = router;
        this.route = route;
        this.toastr = toastr;
        this.storage = storage;
        this.spinnerService = spinnerService;
        this.service = service;
        this.baseurl = location.protocol + '//' + location.host + '/';
        this.response = new Array();
        this.pageIndex = 1;
        this.pageSize = 100;
        this.pageLinks = [];
        this.withd = new _shared_model__WEBPACK_IMPORTED_MODULE_5__["WithdrawApprovalModel"]();
        this.agentUserAdmins = new Array();
        var wid = this.route.snapshot.paramMap.get('id');
        if (wid !== null) {
            this.withdrawalId = Number(wid);
        }
    }
    WithdrawalAgentComponent.prototype.ngOnInit = function () {
        var self = this;
        this.service.GetSystemAdmin().subscribe(function (c) {
            if (c.Succeeded) {
                self.agentUserAdmins = c.Result;
            }
        });
    };
    WithdrawalAgentComponent.prototype.GetWithdrawalStatus = function (status) {
        if (status === 0) {
            return 'Pending';
        }
        else if (status === 1) {
            return 'Approved';
        }
        else if (status === 2) {
            return 'Paid';
        }
    };
    WithdrawalAgentComponent.prototype.Ok = function (model) {
    };
    WithdrawalAgentComponent.prototype.ShowApprovalForm = function (id) {
        // const wid = this.route.snapshot.paramMap.get('id');
        this.router.navigate(['/withdrawalagent', id]);
    };
    WithdrawalAgentComponent.prototype.ApproveWithdrawal = function (model) {
        var self = this;
        this.withd.WithdrawalId = this.withdrawalId;
        this.service.WithdrawalApproval(this.withd).subscribe(function (c) {
            if (c.Succeeded) {
                self.toastr.success('Operation Successful');
            }
            else {
                self.toastr.error(c.Message);
            }
        }, function (e) {
            self.toastr.error('Operation failed ' + e);
        });
    };
    WithdrawalAgentComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-withdrawalagent',
            template: __webpack_require__(/*! ./withdrawalagent.component.html */ "../src/app/withdrawal/withdrawalagent.component.html"),
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"], _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"], _service_storage_service__WEBPACK_IMPORTED_MODULE_2__["StorageService"],
            ng4_loading_spinner__WEBPACK_IMPORTED_MODULE_3__["Ng4LoadingSpinnerService"], _service_withdrawal_service__WEBPACK_IMPORTED_MODULE_6__["WithdrawalService"]])
    ], WithdrawalAgentComponent);
    return WithdrawalAgentComponent;
}());



/***/ }),

/***/ "../src/environments/environment.ts":
/*!******************************************!*\
  !*** ../src/environments/environment.ts ***!
  \******************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "../src/main.ts":
/*!**********************!*\
  !*** ../src/main.ts ***!
  \**********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "../node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "../node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "../src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "../src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!****************************!*\
  !*** multi ../src/main.ts ***!
  \****************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\Abubakar Omolaja G\source\repos\PayAjo\PayAjo\payajouxapp\src\main.ts */"../src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map