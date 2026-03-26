import axios from 'axios';
import qs from 'qs'

const axiosInstance = axios.create({
    baseURL: "/api",
    headers: {
        'Content-Type': 'application/json',
    },
    paramsSerializer: (params) => qs.stringify(params, { arrayFormat: "repeat"})
});

export default axiosInstance;