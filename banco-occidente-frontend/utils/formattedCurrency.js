export const formattedCurrency = (value) => {
    if (value == null) return "";
    return `$${value.toFixed(2)}`;
}