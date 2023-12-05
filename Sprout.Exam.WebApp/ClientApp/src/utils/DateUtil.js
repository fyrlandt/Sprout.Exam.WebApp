class DateUtil {
    static dateTimeToDate(originalDate) {
        var date = new Date(Date.parse(originalDate));
        var formattedDate = date.getFullYear() + "-" + ("0" + (date.getMonth() + 1)).slice(-2) + "-" + ("0" + date.getDate()).slice(-2);
        return formattedDate;
    }
}
export default DateUtil;