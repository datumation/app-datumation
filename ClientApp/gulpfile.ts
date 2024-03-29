import * as gulp from 'gulp';
import * as rimraf from 'rimraf';
import * as concat from 'gulp-concat';
import  cssmin =  require('gulp-cssmin');
import * as uglify from 'gulp-uglify';
const paths = {
  webroot: '../wwwroot/',
  js: '',
  minJs:'',
  css: '',
  minCss: '',
  concatJsDest: '',
  concatCssDest: ''
};

paths.js = paths.webroot + 'js/**/*.js';
paths.minJs = paths.webroot + 'js/**/*.min.js';
paths.css = paths.webroot + 'css/**/*.css';
paths.minCss = paths.webroot + 'css/**/*.min.css';
paths.concatJsDest = paths.webroot + 'js/site.min.js';
paths.concatCssDest = paths.webroot + 'css/site.min.css';

gulp.task('clean:js', done => rimraf(paths.concatJsDest, done));
gulp.task('clean:css', done => rimraf(paths.concatCssDest, done));
gulp.task('clean', gulp.series(['clean:js', 'clean:css']));

gulp.task('min:js', () => {
  return gulp.src([paths.js, '!' + paths.minJs], { base: '.' })
  .pipe(concat(paths.concatJsDest))
  .pipe(uglify())
  .pipe(gulp.dest('.'));
});

gulp.task('min:css', () => {
  return gulp.src([paths.css, '!' + paths.minCss])
  .pipe(concat(paths.concatCssDest))
  .pipe(cssmin())
  .pipe(gulp.dest('.'));
});

gulp.task('min', gulp.series(['min:js', 'min:css']));

// A 'default' task is required by Gulp v4
gulp.task('default', gulp.series(['min']));
