class ValidationUtil {
    static validateEmployeeFields(state) {
        var regexp = /^[\d-]+$/;
        if (!regexp.test(state.tin))
            return "TIN must only contain numbers and dashes.";
        if (state.fullName.trim().length <= 0)
            return "Name is required";
        if (state.birthdate == "")
            return "Birth date is required";
        if (new Date(state.birthdate) > new Date())
            return "Birth date must not be in the future";
        return "";
    }
}
export default ValidationUtil;