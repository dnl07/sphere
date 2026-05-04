export const convertDateFormat = (isoDate: string): string => {
    const date = new Date(isoDate)

    const day = date.getUTCDate()
    const month = date.getMonth()
    const year = date.getFullYear()

    var monthNames = [ "Jan", "Feb", "Mar", "Apr", "May", "Jun",
    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" ];    

    return `${monthNames[month]} ${day}, ${year}`;
}

export const isIsoDateString = (value: string): value is string =>
  typeof value === "string" &&
  /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d+)?Z$/.test(value);
