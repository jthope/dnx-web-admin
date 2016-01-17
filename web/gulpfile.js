/// <binding AfterBuild='min' Clean='clean' />

var gulp = require("gulp"),
	rimraf = require("rimraf"),
	gulpLoadPlugins = require('gulp-load-plugins'),
	plugins = gulpLoadPlugins({
		rename: {
			'gulp-angular-templatecache': 'templateCache'
		}
	}),
	project = require("./project.json");

var paths = {
	webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
	rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
	rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
	gulp.src([paths.js, "!" + paths.minJs], { base: "." })
		.pipe(plugins.concat(paths.concatJsDest))
		.pipe(plugins.uglify())
		.pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
	gulp.src([paths.css, "!" + paths.minCss])
		.pipe(plugins.concat(paths.concatCssDest))
		.pipe(plugins.cssmin())
		.pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);