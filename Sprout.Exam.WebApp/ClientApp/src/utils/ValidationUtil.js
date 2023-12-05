class ValidationUtil {
    static validateEmployeeFields(state) {
        var regexp = /^\d+$/;
        if (!regexp.test(state.tin))
            return "TIN must be a number.";
        if (state.fullName.trim().length <= 0)
            return "Name is required";
        if (state.birthdate == "")
            return "Birth date is required";
        return "";
    }
}
export default ValidationUtil;